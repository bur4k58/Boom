using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.TreeSpeciesCQRS;
using AP.BoomTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.ZoneCQRS
{
    public class ZoneDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string QrCode { get; set; }
        public GrowSiteName GrowSite { get; set; }
        public int GrowSiteId { get; set; }
        public TreeSpeciesName TreeSpecies { get; set; }
        public int TreeSpeciesId { get; set; }
    }
}
