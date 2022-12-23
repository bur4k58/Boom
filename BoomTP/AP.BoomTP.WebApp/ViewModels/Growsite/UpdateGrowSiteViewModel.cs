using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AP.BoomTP.WebApp.ViewModels.Growsite
{
    public class UpdateGrowSiteViewModel
    {
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Display(Name = "Adress")]
        public string Address { get; set; }

        [Display(Name = "Map")]
        public string Map { get; set; }
    }
}
