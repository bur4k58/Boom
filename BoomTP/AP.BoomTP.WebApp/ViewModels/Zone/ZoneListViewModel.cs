using AP.BoomTP.Application.CQRS.TasksCQRS;
using AP.BoomTP.Application.CQRS.TreeSpeciesCQRS;
using AP.BoomTP.Application.CQRS.UserCQRS;
using AP.BoomTP.Application.CQRS.ZoneCQRS;
using AP.BoomTP.WebApp.Controllers;
using AutoMapper.Execution;
using System.Reflection;

namespace AP.BoomTP.WebApp.ViewModels.Zone
{
    public class ZoneListViewModel
    {
        //public SortDirection SortDirection { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<ZoneDTO>? Zones { get; set; }
    }
}
