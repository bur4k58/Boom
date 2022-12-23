using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using AP.BoomTP.WebApp.Controllers;
using AutoMapper.Execution;
using System.Reflection;

namespace AP.BoomTP.WebApp.ViewModels.Schedule
{
    public class ScheduleListViewModel
    {
        //public SortDirection SortDirection { get; set; }
        public SortOrder SortOrder { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<ScheduleDTO>? Schedules { get; set; }
    }
}
