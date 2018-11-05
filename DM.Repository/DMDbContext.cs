using System.Data.Entity;

namespace DM.Repository
{
    public class DMDbContext : DbContext
    {
        public DMDbContext()
            : base("DMDbContext")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
       
        }
        public DbSet<DM.Domain.Sys_User> Sys_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
