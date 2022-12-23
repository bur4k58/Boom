using AP.BoomTP.Domain;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AP.BoomTP.WebApp.ViewModels.Tasks
{
    public class CreateTasksViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is een verplicht veld")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Beschrijving is een verplicht veld")]
        public string Description { get; set; }

        [Display(Name = "TaskTime")]
        [Required(ErrorMessage = "Taakduur is een verplicht veld")]
        public float TaskTime { get; set; }
    }
}
