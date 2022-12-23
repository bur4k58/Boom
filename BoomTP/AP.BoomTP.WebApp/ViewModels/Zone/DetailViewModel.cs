using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.TreeSpeciesCQRS;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AP.BoomTP.WebApp.ViewModels.Zone
{
    public class DetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string QrCode { get; set; }
        public string GrowSiteName { get; set; }
        public string TreeSpeciesName { get; set; }
        public int GrowSiteId { get; set; }
        public int TreeSpeciesId { get; set; }
    }
}
