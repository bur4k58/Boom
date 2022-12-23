using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using AP.BoomTP.Application.CQRS.ScheduleStatusCQRS;
using AP.BoomTP.Application.CQRS.ScheduleTaskCQRS;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace AP.BoomTP.WebApp.Controllers
{
    public class ScheduleTaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/Schedule/{id}");

            var result = await client.GetAsync<ScheduleTaskDetailDTO>(request);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int scheduleId, int taskId)
        {
            var request = new RestRequest();
            var client = new RestClient($"https://localhost:44352/api/v1/ScheduleTask/{scheduleId}/{taskId}");
            await client.DeleteAsync<ScheduleTaskIds>(request);

            return RedirectToAction("Details", "Schedule", new {id = scheduleId});
        }
    }
}
