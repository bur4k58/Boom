using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.Interfaces.GrowSiteI;
using AP.BoomTP.Domain;
using AP.BoomTP.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Infrastructure.Repositories
{
    public class GrowSiteRepository : IGrowSiteRepository
    {
        private readonly BoomTPContext context;

        public GrowSiteRepository(BoomTPContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<GrowSite>> GetAll(int pageNr, int pageSize)
        {
            return await context.GrowSite.Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<GrowSite> GetById(int id)
        {
            return await context.GrowSite.Include(g => g.Zones).FirstOrDefaultAsync(g => g.Id == id);
        }

        public GrowSite Create(GrowSite newGrowSite)
        {
            context.GrowSite.Add(newGrowSite);
            return newGrowSite;
        }
        public GrowSite Update(GrowSite modifiedGrowSite)
        {
            context.GrowSite.Update(modifiedGrowSite);
            return modifiedGrowSite;
        }

        public void Delete(GrowSite growSite)
        {
            context.Remove(growSite);

        }
    }
}
