using AP.BoomTP.Domain;
/*using AP.BoomTP.Infrastructure.Seeding;
*/using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Tasks = AP.BoomTP.Domain.Tasks;

namespace AP.BoomTP.Infrastructure.Contexts
{
    public class BoomTPContext : DbContext
    {
        public BoomTPContext(DbContextOptions<BoomTPContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(m => Debug.WriteLine(m));
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<GrowSite> GrowSite { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TreeSpecies>TreeSpecies { get; set; }
        public DbSet<Zone> Zone { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ScheduleTask> ScheduleTask { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ScheduleTask>().HasKey(s => new { s.ScheduleId, s.TasksId });
            //base.OnModelCreating(modelBuilder);
/*            modelBuilder.Entity<Store>().Seed()
 *            ;
*/        }
    }
}
