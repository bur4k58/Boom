using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.WebApp.Controllers;
using AutoMapper.Execution;
using System.Reflection;

namespace AP.BoomTP.WebApp.ViewModels.Growsite
{
    public class GrowSiteListViewModel
    {
        //public SortDirection SortDirection { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<GrowSiteDTO>? GrowSites { get; set; }
    }
}
