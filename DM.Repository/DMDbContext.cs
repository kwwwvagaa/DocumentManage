


using System.Data.Entity;
using DM.Domain;

namespace DM.Repository
{
    public partial class DMDbContext : DbContext
    {
        public DMDbContext()
            : base("DMDbContext")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
       
        }
        public DbSet<Sys_UserLogOn> Sys_UserLogOns { get; set; }
        public DbSet<Sys_User> Sys_Users { get; set; }
        public DbSet<Sys_RoleAuthorize> Sys_RoleAuthorizes { get; set; }
        public DbSet<Sys_Role> Sys_Roles { get; set; }
        public DbSet<Sys_Organize> Sys_Organizes { get; set; }
        public DbSet<Sys_ModuleFormInstance> Sys_ModuleFormInstances { get; set; }
        public DbSet<Sys_ModuleForm> Sys_ModuleForms { get; set; }
        public DbSet<Sys_ModuleButton> Sys_ModuleButtons { get; set; }
        public DbSet<Sys_Module> Sys_Modules { get; set; }
        public DbSet<Sys_Log> Sys_Logs { get; set; }
        public DbSet<Sys_ItemsDetail> Sys_ItemsDetails { get; set; }
        public DbSet<Sys_Items> Sys_Itemss { get; set; }
        public DbSet<Sys_FilterIP> Sys_FilterIPs { get; set; }
        public DbSet<Sys_DbBackup> Sys_DbBackups { get; set; }
        public DbSet<Sys_Area> Sys_Areas { get; set; }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
