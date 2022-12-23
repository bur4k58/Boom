using AP.BoomTP.Application.CQRS.TasksCQRS;
using AP.BoomTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.TreeSpeciesCQRS
{
    public class TreeSpeciesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MaintenanceInstructions { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<TasksDTO> Tasks { get; set; }
    }
}
