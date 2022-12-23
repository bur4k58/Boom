using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.TreeSpeciesCQRS;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AP.BoomTP.WebApp.ViewModels.Zone
{
    public class UpdateZoneViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Size")]
        public string Size { get; set; }


        [Display(Name = "QrCode")]
        public string QrCode { get; set; }

        [Display(Name = "GrowSiteId")]
        public int GrowSiteId { get; set; }

        [Display(Name = "TreeSpeciesId")]
        public int TreeSpeciesId { get; set; }
        public IEnumerable<GrowSiteDTO>? GrowSites { get; set; }
        public IEnumerable<TreeSpeciesDTO>? Trees { get; set; }
    }
}
