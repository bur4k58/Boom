using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string AuthId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public Role Role { get; set; } 
        public ContractType ContractType { get; set; }
    }
    public enum ContractType
    {
        Fulltime,
        Parttime
    }
    public enum Role
    {
        Admin,
        Responsible,
        Worker
    }
}
