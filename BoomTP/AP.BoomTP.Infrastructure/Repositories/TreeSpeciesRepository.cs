using AP.BoomTP.Application.Interfaces.TreeSpeciesI;
using AP.BoomTP.Domain;
using AP.BoomTP.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Infrastructure.Repositories
{
    public class TreeSpeciesRepository : ITreeSpeciesRepository
    {
        private readonly BoomTPContext context;

        public TreeSpeciesRepository(BoomTPContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<TreeSpecies>> GetAll(int pageNr, int pageSize)
        {
            return await context.TreeSpecies.Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<TreeSpecies> GetById(int id)
        {
            return await context.TreeSpecies.Include(z => z.Zones).
                Include(t => t.Tasks).
                FirstOrDefaultAsync(p => p.Id == id);
        }
        public TreeSpecies Create(TreeSpecies newTreeSpecie)
        {
            context.TreeSpecies.Add(newTreeSpecie);
            return newTreeSpecie;
        }
        public TreeSpecies Update(TreeSpecies modifiedTreeSpecies)
        {
            context.TreeSpecies.Update(modifiedTreeSpecies);
            return modifiedTreeSpecies;
        }

        public void Delete(TreeSpecies treeSpecies)
        {
            context.Remove(treeSpecies);
        }
        public TreeSpecies DeleteTreeSpecies(int id)
        {
            var treeSpecies = context.TreeSpecies.FirstOrDefault(p => p.Id == id);
            context.TreeSpecies.Remove(treeSpecies);
            return treeSpecies;
        }

    }
}
