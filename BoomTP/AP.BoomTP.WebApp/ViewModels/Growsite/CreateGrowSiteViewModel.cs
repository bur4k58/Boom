using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AP.BoomTP.WebApp.ViewModels.Growsite
{
    public class CreateGrowSiteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Naam")]
        [Required(ErrorMessage = "Naam is een verplicht veld")]
        public string Name { get; set; }

        [Display(Name = "Adress")]
        [Required(ErrorMessage = "Adress is een verplicht veld")]
        public string Address { get; set; }
        public IFormFile Map { get; set; }
    }
}
