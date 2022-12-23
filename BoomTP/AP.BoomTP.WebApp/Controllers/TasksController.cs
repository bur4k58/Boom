using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.TasksCQRS;
using AP.BoomTP.WebApp.ViewModels.Growsite;
using AP.BoomTP.WebApp.ViewModels.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;

namespace AP.BoomTP.WebApp.Controllers
{
    public class TasksController : Controller
    {
       
        public TasksController()
        {

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTasksViewModel createTasksViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient("https://localhost:44352/api/v1/Tasks");
                var request = new RestRequest().AddJsonBody(
                    new Application.CQRS.TasksCQRS.CreateTasksCommand()
                    {
                        Title = createTasksViewModel.Title,
                        Description = createTasksViewModel.Description,
                        TaskTime = createTasksViewModel.TaskTime
                    });
                await client.PostAsync<TasksDTO>(request);

                return RedirectToAction("Index", "Tasks");
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin, Responsible")]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] int page = 1)
        {
            var request = new RestRequest();
            var client = new RestClient("https://localhost:44352/api/v1/Tasks?pageSize=10000");
            var result = await client.GetAsync<IEnumerable<TasksDTO>>(request);
            TaskListViewModel taskListViewModel = new TaskListViewModel
            {
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)result.Count() / 10),
                Tasks = result.Skip((page - 1) * 10).Take(10)
            };
            return View(taskListViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/Tasks/{id}");
            await client.DeleteAsync<TasksId>(request);

            return RedirectToAction("Index", "Tasks");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/Tasks/{id}");
            var result = await client.GetAsync<TasksDTO>(request);

            if (result != null)
            {
                UpdateTasksViewModel updateTasks = new UpdateTasksViewModel
                {
                    Title = result.Title,
                    Description = result.Description,
                    TaskTime = result.TaskTime
                };

                return View(updateTasks);

            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateTasksViewModel updateTasksViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient($"https://localhost:44352/api/v1/Tasks/{id}");
                var request = new RestRequest().AddJsonBody(
                    new UpdateTasksCommand()
                    {
                        Id = id,
                        Title = updateTasksViewModel.Title,
                        Description = updateTasksViewModel.Description,
                        TaskTime = updateTasksViewModel.TaskTime
                    });
                await client.PutAsync<TasksDTO>(request);

                return RedirectToAction("Index", "Tasks");
            }
            else
            {
                return View();
            }
        }

    }
}
