using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Domain
{
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string QrCode { get; set; }
        public int GrowSiteId { get; set; }
        public GrowSite GrowSite { get; set; }
        public int TreeSpeciesId { get; set; }
        public TreeSpecies TreeSpecies { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
