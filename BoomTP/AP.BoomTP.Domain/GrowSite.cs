using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Domain
{
    public class GrowSite
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Map { get; set; }      
        
        public ICollection<Zone> Zones { get; set; }
    }
}
