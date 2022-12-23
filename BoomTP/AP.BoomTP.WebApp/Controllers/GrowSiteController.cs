using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.WebApp.ViewModels.Growsite;
using AP.BoomTP.WebApp.ViewModels.Schedule;
using AP.BoomTP.WebApp.ViewModels.TreeSpecies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace AP.BoomTP.WebApp.Controllers
{
    public class GrowSiteController : Controller
    {
        private readonly IWebHostEnvironment env;
        public GrowSiteController(IWebHostEnvironment webHostEnvironment)
        {
            env = webHostEnvironment;

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGrowSiteViewModel createGrowSiteViewModel)
        {
            string fileNameAfbeelding = UploadImageFile(createGrowSiteViewModel);

            if (ModelState.IsValid)
            {
                var client = new RestClient("https://localhost:44352/api/v1/GrowSite");
                var request = new RestRequest().AddJsonBody(
                    new CreateGrowSiteCommand()
                    {
                        Name = createGrowSiteViewModel.Name,
                        Address = createGrowSiteViewModel.Address,
                        Map = fileNameAfbeelding
                    });
                await client.PostAsync<GrowSiteDTO>(request);

                return RedirectToAction("Index", "Growsite");
            }
            else
            {
                return View();
            }
        }

        private string UploadImageFile(CreateGrowSiteViewModel createGrowSiteViewModel)
        {
            string fileName = "";
            if (createGrowSiteViewModel.Map != null)
            {
                string uploadDir = Path.Combine(env.WebRootPath, "images");
                fileName = createGrowSiteViewModel.Map.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    createGrowSiteViewModel.Map.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/GrowSite/{id}");
            var result = await client.GetAsync<GrowSiteDTO>(request);

            if (result != null)
            {
                UpdateGrowSiteViewModel updateGrowSite = new UpdateGrowSiteViewModel
                {
                    Name=result.Name,
                    Map = result.Map,
                    Address = result.Address
                };
                return View(updateGrowSite);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateGrowSiteViewModel updateGrowSiteViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient($"https://localhost:44352/api/v1/GrowSite/{id}");
                var request = new RestRequest().AddJsonBody(
                    new UpdateGrowSiteCommand()
                    {
                        Id = id,
                        Name = updateGrowSiteViewModel.Name,
                        Address = updateGrowSiteViewModel.Address,
                        Map = updateGrowSiteViewModel.Map
                    });
                await client.PutAsync<GrowSiteDTO>(request);

                return RedirectToAction("Index", "Growsite");
            }
            else
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] int page = 1)
        {
            var request = new RestRequest();
            var client = new RestClient("https://localhost:44352/api/v1/GrowSite?pageSize=10000");
            var result = await client.GetAsync<IEnumerable<GrowSiteDTO>>(request);
            GrowSiteListViewModel growSiteListViewModel = new GrowSiteListViewModel
            {
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)result.Count() / 10),
                GrowSites = result.Skip((page - 1) * 10).Take(10)
            };
            return View(growSiteListViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/GrowSite/{id}");

            var result = await client.GetAsync<GrowSiteDetailDTO>(request);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/GrowSite/{id}");
            await client.DeleteAsync<GrowSiteId>(request);

            return RedirectToAction("Index", "GrowSite");
        }
    }
}
