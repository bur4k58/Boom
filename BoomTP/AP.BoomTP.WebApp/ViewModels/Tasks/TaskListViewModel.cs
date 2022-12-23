using AP.BoomTP.Application.CQRS.TasksCQRS;
using AP.BoomTP.WebApp.Controllers;
using AutoMapper.Execution;
using System.Reflection;

namespace AP.BoomTP.WebApp.ViewModels.Tasks
{
    public class TaskListViewModel
    {
        //public SortDirection SortDirection { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<TasksDTO>? Tasks { get; set; }
    }
}
