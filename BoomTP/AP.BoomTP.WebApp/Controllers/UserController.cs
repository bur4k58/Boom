using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.UserCQRS;
using AP.BoomTP.WebApp.ViewModels.Growsite;
using AP.BoomTP.WebApp.ViewModels.TreeSpecies;
using AP.BoomTP.WebApp.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;

namespace AP.BoomTP.WebApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserVievModel createUserVievModel)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient("https://localhost:44352/api/v1/User");
                var request = new RestRequest().AddJsonBody(
                    new CreateUserCommand()
                    {
                        FirstName = createUserVievModel.FirstName,
                        LastName = createUserVievModel.LastName,
                        AuthId = createUserVievModel.AuthId,
                        Email = createUserVievModel.Email,
                        ContractType = createUserVievModel.ContractType,
                        Role = createUserVievModel.Role
                    });
                await client.PostAsync<UserDTO>(request);

                return RedirectToAction("Index", "User");
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
            var client = new RestClient("https://localhost:44352/api/v1/User?pageSize=10000");
            var result = await client.GetAsync<IEnumerable<UserDTO>>(request);
            UserListViewModel userListViewModel = new UserListViewModel
            {
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)result.Count() / 10),
                Users = result.Skip((page - 1) * 10).Take(10)
            };
            return View(userListViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/User/{id}");

            var result = await client.GetAsync<UserDTO>(request);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/User/{id}");
            await client.DeleteAsync<UserId>(request);

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/User/{id}");
            var result = await client.GetAsync<UserDTO>(request);

            if (result != null)
            {
                UpdateUserViewModel updateUser = new UpdateUserViewModel
                {
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Email = result.Email,
                    AuthId = result.AuthId,
                    ContractType = result.ContractType,
                    Role = result.Role
                };
                return View(updateUser);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateUserViewModel updateUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient($"https://localhost:44352/api/v1/User/{id}");
                var request = new RestRequest().AddJsonBody(
                    new UpdateUserCommand()
                    {
                        Id = id,
                        FirstName = updateUserViewModel.FirstName,
                        LastName = updateUserViewModel.LastName,
                        AuthId = updateUserViewModel.AuthId,
                        Role = updateUserViewModel.Role,
                        ContractType = updateUserViewModel.ContractType,
                        Email = updateUserViewModel.Email
                    });
                await client.PutAsync<UserDTO>(request);

                return RedirectToAction("Index", "User");
            }
            else
            {
                return View();
            }
        }
    }
}
