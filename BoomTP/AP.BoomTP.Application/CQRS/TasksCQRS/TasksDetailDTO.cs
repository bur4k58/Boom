using AP.BoomTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.TasksCQRS
{
    public class TasksDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float TaskTime { get; set; }
        public ICollection<TreeSpecies> TaskHasTreeSpecies { get; set; }
        public ICollection<TreeSpecies> TreeSpecies { get; set; }
    }
}
