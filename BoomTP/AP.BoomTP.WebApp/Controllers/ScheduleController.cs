using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using AP.BoomTP.Application.CQRS.ScheduleStatusCQRS;
using AP.BoomTP.Application.CQRS.TasksCQRS;
using AP.BoomTP.Application.CQRS.UserCQRS;
using AP.BoomTP.Application.CQRS.ZoneCQRS;
using AP.BoomTP.Domain;
using AP.BoomTP.WebApp.Models;
using AP.BoomTP.WebApp.ViewModels.Schedule;
using AP.BoomTP.WebApp.ViewModels.TreeSpecies;
using AutoMapper.Execution;
using Cuemon;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Globalization;
using Role = AP.BoomTP.Application.CQRS.UserCQRS.Role;

namespace AP.BoomTP.WebApp.Controllers
{
    public enum SortOrder
    {
        Week,
        All
    }
    public class ScheduleController : Controller
    {
        public ScheduleController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var requestZone = new RestRequest();
            var clientZone = new RestClient($"https://localhost:44352/api/v1/Zone");
            var resultZone = await clientZone.GetAsync<IEnumerable<ZoneDTO>>(requestZone);

            var requestUser = new RestRequest();
            var clientUser = new RestClient($"https://localhost:44352/api/v1/User");
            var resultUser = await clientUser.GetAsync<IEnumerable<UserDTO>>(requestUser);
            IEnumerable<UserDTO> filteredListUser = resultUser.Where(x => x.Role == Role.Worker);

            var requestTask = new RestRequest();
            var clientTask = new RestClient($"https://localhost:44352/api/v1/Tasks");
            var resultTask = await clientTask.GetAsync<IEnumerable<TasksDTO>>(requestTask);

            if (resultZone != null && resultUser != null)
            {
                CreateScheduleViewModel getCreateViewModel = new CreateScheduleViewModel
                {
                    Tasks = resultTask,
                    Users = filteredListUser,
                    Zones = resultZone
                };
                return View(getCreateViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "Admin, Responsible")]
        [HttpGet]
        public async Task<IActionResult> Index(string searchString, [FromQuery] int page = 1, [FromQuery] SortOrder sortOrder = SortOrder.All)
        {
            Calendar cal = new CultureInfo("en-US").Calendar;
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/Schedule?pageSize=10000");
            var result = await client.GetAsync<IEnumerable<ScheduleDTO>>(request);
            switch (sortOrder)
            {
                case SortOrder.Week:
                    result = result.OrderBy(s => s.Date.Date).Where(p => cal.GetWeekOfYear(p.Date.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday) == cal.GetWeekOfYear(DateTime.Now.Date.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday));
                    break;
                case SortOrder.All:
                    break;
                default:
                    break;
            }
            ScheduleListViewModel scheduleListViewModel = new ScheduleListViewModel
            {
                SortOrder = sortOrder,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)result.Count() / 10),
                Schedules = result.Skip((page - 1) * 10).Take(10)
            };
            return View(scheduleListViewModel);
        }

        [Authorize(Roles = "Admin, Responsible")]
        [HttpGet]
        public async Task<IActionResult> Late(string searchString, [FromQuery] int page = 1, [FromQuery] SortOrder sortOrder = SortOrder.All)
        {
            var request = new RestRequest();
            var client = new RestClient("https://localhost:44352/api/v1/Schedule/getbehindschedule?pageSize=10000");
            var result = await client.GetAsync<IEnumerable<ScheduleDTO>>(request);
            result = result.Where(p => p.ScheduleTask.Count() > 0);
            ScheduleListViewModel scheduleListViewModel = new ScheduleListViewModel
            {
                SortOrder = sortOrder,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)result.Count() / 10),
                Schedules = result.Skip((page - 1) * 10).Take(10)
            };
            return View(scheduleListViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var requestSchedule = new RestRequest();
            var clientSchedule = new RestClient($"https://localhost:44352/api/v1/Schedule/{id}");
            var resultSchedule = await clientSchedule.GetAsync<ScheduleDetailDTO>(requestSchedule);

            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/ScheduleTask/{id}");
            var result = await client.GetAsync<IEnumerable<ScheduleTaskDetailDTO>>(request);


            if (resultSchedule != null && result != null)
            {
                DetailViewModel detailViewModel = new DetailViewModel
                {
                    ScheduleTasks = result,
                    Schedule = resultSchedule
                };
                return View(detailViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateScheduleViewModel createScheduleViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient("https://localhost:44352/api/v1/Schedule");
                var request = new RestRequest().AddJsonBody(
                    new CreateScheduleCommand()
                    {
                        Date = createScheduleViewModel.Date,
                        UserId = createScheduleViewModel.UserId,
                        ZoneId = createScheduleViewModel.ZoneId,
                        TaskId = createScheduleViewModel.TaskId
                    });

                var response = await client.ExecutePostAsync<ScheduleDetailDTO>(request);
                JObject obj = JObject.Parse(response.Content);
                string message = (string)obj["Message"];
                int errorCode = ((int)response.StatusCode);

                if (errorCode == 400)
                {
                    return StatusCode(400, message);
                }
                else
                {
                    return RedirectToAction("Index", "Schedule");
                }
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
            var client = new RestClient($"https://localhost:44352/api/v1/Schedule/{id}");
            var result = await client.GetAsync<ScheduleDTO>(request);

            var requestZone = new RestRequest();
            var clientZone = new RestClient($"https://localhost:44352/api/v1/Zone");
            var resultZone = await clientZone.GetAsync<IEnumerable<ZoneDTO>>(requestZone);

            var requestUser = new RestRequest();
            var clientUser = new RestClient($"https://localhost:44352/api/v1/User");
            var resultUser = await clientUser.GetAsync<IEnumerable<UserDTO>>(requestUser);
            IEnumerable<UserDTO> filteredListUser = resultUser.Where(x => x.Role == Role.Worker);


            var requestTask = new RestRequest();
            var clientTask = new RestClient($"https://localhost:44352/api/v1/Tasks");
            var resultTask = await clientTask.GetAsync<IEnumerable<TasksDTO>>(requestTask);

            if (result != null)
            {
                UpdateScheduleViewModel updateScheduleViewModel = new UpdateScheduleViewModel
                {
                    Date = result.Date,
                    UserId = result.UserId, 
                    ZoneId = result.ZoneId,
                    Tasks = resultTask,
                    Users = filteredListUser,
                    Zones = resultZone
                };
                return View(updateScheduleViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateScheduleViewModel updateScheduleViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient($"https://localhost:44352/api/v1/Schedule/{id}");
                var request = new RestRequest().AddJsonBody(
                    new UpdateScheduleCommand()
                    {
                        Id = id,
                        Date = updateScheduleViewModel.Date,
                        UserId = updateScheduleViewModel.UserId,
                        ZoneId = updateScheduleViewModel.ZoneId,
                        TaskId = updateScheduleViewModel.TaskId
                    });
                await client.PutAsync<ScheduleDetailDTO>(request);

                return RedirectToAction("Index", "Schedule");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/Schedule/{id}");
            await client.DeleteAsync<ScheduleId>(request);

            return RedirectToAction("Index", "Schedule");
        }
    }
}
