using AP.BoomTP.Application.CQRS.ZoneCQRS;
using AP.BoomTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.GrowSiteCQRS
{
    public class GrowSiteDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Map { get; set; }
        public ICollection<ZoneDTO> Zones { get; set; }
    }
}
