using AP.BoomTP.Application.CQRS.TreeSpeciesCQRS;
using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AP.BoomTP.WebApp.ViewModels.Zone
{
    public class CreateZoneViewModel
    {

        public int Id { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Naam is een verplicht veld")]
        public string Name { get; set; }

        [Display(Name = "Size")]
        [Required(ErrorMessage = "Grootte is een verplicht veld")]
        public string Size { get; set; }

        public IFormFile QrCode { get; set; }
        public IEnumerable<GrowSiteDTO>? GrowSites { get; set; }
        public IEnumerable<TreeSpeciesDTO>? Trees { get; set; }

        [Required(ErrorMessage = "Kweeksite is een verplicht veld")]
        public int GrowSiteId { get; set; }

        [Required(ErrorMessage = "Boomsoort is een verplicht veld")]
        public int TreeSpeciesId { get; set; }
    }
}
