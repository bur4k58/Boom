using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using AP.BoomTP.Application.CQRS.ScheduleStatusCQRS;
using AP.BoomTP.Application.CQRS.TasksCQRS;
using AP.BoomTP.Application.CQRS.UserCQRS;
using AP.BoomTP.Application.CQRS.ZoneCQRS;
using AP.BoomTP.Domain;

namespace AP.BoomTP.WebApp.ViewModels.Schedule
{
    public class DetailViewModel
    {
        public ScheduleDetailDTO Schedule { get; set; }
        public IEnumerable<ScheduleTaskDetailDTO>? ScheduleTasks { get; set; }
    }
}
