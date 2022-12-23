using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Domain
{
    public class TreeSpecies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MaintenanceInstructions { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
        public ICollection<Zone> Zones { get; set; }

    }
}
