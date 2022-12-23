using AP.BoomTP.Application.CQRS.TasksCQRS;
using AP.BoomTP.Application.CQRS.TreeSpeciesCQRS;
using AP.BoomTP.WebApp.Controllers;
using AutoMapper.Execution;
using System.Reflection;

namespace AP.BoomTP.WebApp.ViewModels.TreeSpecies
{
    public class TreeSpeciesListViewModel
    {
        //public SortDirection SortDirection { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<TreeSpeciesDTO>? TreeSpecies { get; set; }
    }
}
