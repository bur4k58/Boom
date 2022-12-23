using AP.BoomTP.Application.CQRS.TasksCQRS;
using AP.BoomTP.Application.CQRS.TreeSpeciesCQRS;
using AP.BoomTP.Domain;
using AP.BoomTP.WebApp.ViewModels.Tasks;
using AP.BoomTP.WebApp.ViewModels.TreeSpecies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;

namespace AP.BoomTP.WebApp.Controllers
{
    public class TreeSpeciesController : Controller
    {
        private readonly IWebHostEnvironment env;
        public TreeSpeciesController(IWebHostEnvironment webHostEnvironment)
        {
            env = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var requestTask = new RestRequest();
            var clientTask = new RestClient($"https://localhost:44352/api/v1/Tasks");
            var resultTask = await clientTask.GetAsync<IEnumerable<TasksDTO>>(requestTask);

            if (resultTask != null)
            {
                CreateTreeSpeciesViewModel getCreateViewModel = new CreateTreeSpeciesViewModel
                {
                    Tasks = resultTask
                };
                return View(getCreateViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTreeSpeciesViewModel createTreeSpeciesViewModel)
        {
            string fileNameAfbeelding = UploadImageFile(createTreeSpeciesViewModel);
            string fileNamePDf = UploadPdfFile(createTreeSpeciesViewModel);

            if (ModelState.IsValid)
            {
                var client = new RestClient("https://localhost:44352/api/v1/TreeSpecies");
                var request = new RestRequest().AddJsonBody(
                    new CreateTreeSpeciesCommand()
                    {
                        Name = createTreeSpeciesViewModel.Name,
                        MaintenanceInstructions = fileNamePDf,
                        ImageUrl = fileNameAfbeelding,
                        TaskId = createTreeSpeciesViewModel.TaskId
                    });
                await client.PostAsync<TreeSpeciesDTO>(request);

                return RedirectToAction("Index", "TreeSpecies");
            }
            else
            {
                return View();
            }
        }

        private string UploadPdfFile(CreateTreeSpeciesViewModel createTreeSpeciesViewModel)
        {
            string fileName = "";
            if (createTreeSpeciesViewModel.MaintenanceInstructions != null)
            {
                string uploadDir = Path.Combine(env.WebRootPath, "pdf");
                fileName = createTreeSpeciesViewModel.MaintenanceInstructions.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    createTreeSpeciesViewModel.MaintenanceInstructions.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        private string UploadImageFile(CreateTreeSpeciesViewModel createTreeSpeciesViewModel)
        {
            string fileName = "";
            if (createTreeSpeciesViewModel.ImageUrl != null)
            {
                string uploadDir = Path.Combine(env.WebRootPath, "images");
                fileName = createTreeSpeciesViewModel.ImageUrl.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    createTreeSpeciesViewModel.ImageUrl.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] int page = 1)
        {
            var request = new RestRequest();
            var client = new RestClient("https://localhost:44352/api/v1/TreeSpecies?pageSize=10000");
            var result = await client.GetAsync<IEnumerable<TreeSpeciesDTO>>(request);
            TreeSpeciesListViewModel treeSpeciesListViewModel = new TreeSpeciesListViewModel
            {
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)result.Count() / 10),
                TreeSpecies = result.Skip((page - 1) * 10).Take(10)
            };
            return View(treeSpeciesListViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/TreeSpecies/{id}");
            var result = await client.GetAsync<TreeSpeciesDetailDTO>(request);

            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/TreeSpecies/{id}");
            await client.DeleteAsync<TreeSpeciesId>(request);

            return RedirectToAction("Index", "Treespecies");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/TreeSpecies/{id}");
            var result = await client.GetAsync<TreeSpeciesDTO>(request);

            var requestTask = new RestRequest();
            var clientTask = new RestClient($"https://localhost:44352/api/v1/Tasks");
            var resultTask = await clientTask.GetAsync<IEnumerable<TasksDTO>>(requestTask);

            if (result != null)
            {
                UpdateTreeSpeciesViewModel updateTreeSpecies = new UpdateTreeSpeciesViewModel
                {
                    Name = result.Name,
                    MaintenanceInstructions = result.MaintenanceInstructions,
                    ImageUrl = result.ImageUrl,
                    Tasks = resultTask
                };
                return View(updateTreeSpecies);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateTreeSpeciesViewModel updateTreeSpeciesViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient($"https://localhost:44352/api/v1/TreeSpecies/{id}");
                var request = new RestRequest().AddJsonBody(
                    new UpdateTreeSpeciesCommand()
                    {
                        Id = id,
                        Name = updateTreeSpeciesViewModel.Name,
                        MaintenanceInstructions = updateTreeSpeciesViewModel.MaintenanceInstructions,
                        ImageUrl = updateTreeSpeciesViewModel.ImageUrl,
                        TaskId = updateTreeSpeciesViewModel.TaskId
                    });
                await client.PutAsync<TreeSpeciesDTO>(request);

                return RedirectToAction("Index", "Treespecies");
            }
            else
            {
                return View();
            }
        }
    }
}
