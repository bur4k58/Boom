using AP.BoomTP.Application.CQRS.TasksCQRS;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AP.BoomTP.WebApp.ViewModels.TreeSpecies
{
    public class CreateTreeSpeciesViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Naam is een verplicht veld")]
        public string Name { get; set; }

        [Display(Name = "MaintenanceInstructions")]
        [Required(ErrorMessage = "PDF is een verplicht veld")]
        public IFormFile MaintenanceInstructions { get; set; }

        [Display(Name = "ImageUrl")]
        [Required(ErrorMessage = "Afbeelding is een verplicht veld")]
        public IFormFile ImageUrl { get; set; }
        public int[]? TaskId { get; set; }
        public IEnumerable<TasksDTO>? Tasks { get; set; }
    }
}
