using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using AP.BoomTP.Application.CQRS.TreeSpeciesCQRS;
using AP.BoomTP.Application.CQRS.ZoneCQRS;
using AP.BoomTP.WebApp.ViewModels.TreeSpecies;
using AP.BoomTP.WebApp.ViewModels.Zone;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AP.BoomTP.WebApp.Controllers
{
    public class ZoneController : Controller
    {
        private readonly IWebHostEnvironment env;
        public ZoneController(IWebHostEnvironment webHostEnvironment)
        {
            env = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var requestGrowSite = new RestRequest();
            var clientGrowSite = new RestClient($"https://localhost:44352/api/v1/GrowSite");
            var resultGrowSite = await clientGrowSite.GetAsync<IEnumerable<GrowSiteDTO>>(requestGrowSite);

            var requestTreeSpecies = new RestRequest();
            var clientTreeSpecies = new RestClient($"https://localhost:44352/api/v1/TreeSpecies");
            var resultTreeSpecies = await clientTreeSpecies.GetAsync<IEnumerable<TreeSpeciesDTO>>(requestTreeSpecies);

            if (resultGrowSite != null && resultTreeSpecies != null)
            {
                CreateZoneViewModel getCreateZoneViewModel = new CreateZoneViewModel
                {
                    GrowSites = resultGrowSite,
                    Trees = resultTreeSpecies
                };
                return View(getCreateZoneViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateZoneViewModel createZoneViewModel)
        {
            string fileNameAfbeelding = UploadImageFile(createZoneViewModel);

            if (ModelState.IsValid)
            {
                var client = new RestClient("https://localhost:44352/api/v1/Zone");
                var request = new RestRequest().AddJsonBody(
                    new CreateZoneCommand()
                    {
                        QrCode = fileNameAfbeelding,
                        Name = createZoneViewModel.Name,
                        Size = createZoneViewModel.Size,
                        TreeSpeciesId = createZoneViewModel.TreeSpeciesId,
                        GrowSiteId = createZoneViewModel.GrowSiteId
                    });

                var response = await client.ExecutePostAsync<ZoneDTO>(request);
                JObject obj = JObject.Parse(response.Content);
                string message = (string)obj["Message"];
                int errorCode = ((int)response.StatusCode);

                if (errorCode == 400)
                {
                    return StatusCode(400, message);
                }
                else
                {
                    return RedirectToAction("Index", "Zone");
                }
            }
            else
            {
                return View();
            }
        }

        private string UploadImageFile(CreateZoneViewModel createZoneViewModel)
        {
            string fileName = "";
            if (createZoneViewModel.QrCode != null)
            {
                string uploadDir = Path.Combine(env.WebRootPath, "images");
                fileName = createZoneViewModel.QrCode.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    createZoneViewModel.QrCode.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] int page = 1)
        {
            var request = new RestRequest();
            var client = new RestClient("https://localhost:44352/api/v1/Zone?pageSize=10000");
            var result = await client.GetAsync<IEnumerable<ZoneDTO>>(request);
            ZoneListViewModel zoneListViewModel = new ZoneListViewModel
            {
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)result.Count() / 10),
                Zones = result.Skip((page - 1) * 10).Take(10)
            };
            return View(zoneListViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/Zone/{id}");
            var result = await client.GetAsync<ZoneDTO>(request);

            var requestGrowSite = new RestRequest();
            var clientGrowSite = new RestClient($"https://localhost:44352/api/v1/GrowSite/{result.GrowSiteId}");
            var resultGrowSite = await clientGrowSite.GetAsync<GrowSiteDetailDTO>(requestGrowSite);

            var requestTreeSpecies = new RestRequest();
            var clientTreeSpecies = new RestClient($"https://localhost:44352/api/v1/TreeSpecies/{result.TreeSpeciesId}");
            var resultTreeSpecies = await clientTreeSpecies.GetAsync<TreeSpeciesDetailDTO>(requestTreeSpecies);

            DetailViewModel detailViewModel = new DetailViewModel
            {
                Name = result.Name,
                Size = result.Size,
                QrCode = result.QrCode,
                GrowSiteId = resultGrowSite.Id,
                TreeSpeciesId = resultTreeSpecies.Id,
                TreeSpeciesName = resultTreeSpecies.Name,
                GrowSiteName = resultGrowSite.Name
            };

            return View(detailViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/Zone/{id}");
            await client.DeleteAsync<ZoneId>(request);

            return RedirectToAction("Index", "Zone");
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateZoneViewModel updateZoneViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient($"https://localhost:44352/api/v1/Zone/{id}");
                var request = new RestRequest().AddJsonBody(
                    new UpdateZoneCommand()
                    {
                        Id = id,
                        Name = updateZoneViewModel.Name,
                        Size = updateZoneViewModel.Size,
                        QrCode = updateZoneViewModel.QrCode,
                        GrowSiteId = updateZoneViewModel.GrowSiteId,
                        TreeSpeciesId = updateZoneViewModel.TreeSpeciesId
                    });
                await client.PutAsync<ZoneDTO>(request);

                return RedirectToAction("Index", "Zone");
            }
            else
            {
                return View();
            }


        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/Zone/{id}");
            var result = await client.GetAsync<ZoneDTO>(request);

            var requestGrowSite = new RestRequest();
            var clientGrowSite = new RestClient($"https://localhost:44352/api/v1/GrowSite");
            var resultGrowSite = await clientGrowSite.GetAsync<IEnumerable<GrowSiteDTO>>(requestGrowSite);

            var requestTreeSpecies = new RestRequest();
            var clientTreeSpecies = new RestClient($"https://localhost:44352/api/v1/TreeSpecies");
            var resultTreeSpecies = await clientTreeSpecies.GetAsync<IEnumerable<TreeSpeciesDTO>>(requestTreeSpecies);

            if (result != null)
            {
                UpdateZoneViewModel updateZone = new UpdateZoneViewModel
                {
                    Name = result.Name,
                    Size = result.Size,
                    QrCode = result.QrCode,
                    GrowSites = resultGrowSite,
                    Trees = resultTreeSpecies,
                    GrowSiteId = result.GrowSiteId,
                    TreeSpeciesId = result.TreeSpeciesId

                };
                return View(updateZone);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
