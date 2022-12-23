using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AP.BoomTP.Application.Interfaces.ZoneI;
using System.Threading.Tasks;
using AP.BoomTP.Domain;
using AP.BoomTP.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AP.BoomTP.Infrastructure.Repositories
{
    public class ZoneRepository : IZoneRespository
    {
        private readonly BoomTPContext context;

        public ZoneRepository(BoomTPContext context)
        {
            this.context = context;
        }

        public Zone Create(Zone newZone)
        {
            context.Zone.Add(newZone);
            return newZone;
        }

        public void Delete(Zone zone)
        {
            context.Remove(zone);
        }
        public Zone DeleteZone(int id)
        {
            var zoneD = context.Zone.FirstOrDefault(p => p.Id == id);
            context.Zone.Remove(zoneD);
            return zoneD;
        }

        public async Task<IEnumerable<Zone>> GetAll(int pageNr, int pageSize)
        {
            return await context.Zone.Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<Zone> GetById(int id)
        {
            return await context.Zone.Include(t => t.TreeSpecies).Include(g => g.GrowSite).FirstOrDefaultAsync(p => p.Id == id);
        }
        public Zone Update(Zone modifiedZone)
        {
            context.Zone.Update(modifiedZone);
            return modifiedZone;
        }
        public async Task<List<Zone>> GetAllZoneByGrowSiteAndTreeSpecies(int growSiteId, int treeSpeciesId)
        {
            return await context.Zone.Where(x => x.TreeSpeciesId == treeSpeciesId && x.GrowSiteId == growSiteId).ToListAsync();
        }
    }
}
