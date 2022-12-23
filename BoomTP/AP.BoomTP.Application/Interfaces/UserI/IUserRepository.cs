using AP.BoomTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.Interfaces.UserI
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetByAuthIdFilter(string id);
        Task<List<User>> GetByAuthId(string id);
    }
}
