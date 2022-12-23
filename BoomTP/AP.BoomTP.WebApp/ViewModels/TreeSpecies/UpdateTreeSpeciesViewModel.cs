using AP.BoomTP.Application.CQRS.TasksCQRS;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AP.BoomTP.WebApp.ViewModels.TreeSpecies
{
    public class UpdateTreeSpeciesViewModel
    {
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Display(Name = "OnderhoudInstructies")]
        public string MaintenanceInstructions { get; set; }
        public string ImageUrl { get; set; }
        public int[] TaskId { get; set; }
        public IEnumerable<TasksDTO>? Tasks { get; set; }
    }
}
