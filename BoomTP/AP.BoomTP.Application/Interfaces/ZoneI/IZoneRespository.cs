using AP.BoomTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.Interfaces.ZoneI
{
    public interface IZoneRespository : IGenericRepository<Zone>
    {
        Task<List<Zone>> GetAllZoneByGrowSiteAndTreeSpecies(int growSiteId, int TreeSpeciesId);
    }
}
