using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("name=MyContextConnStr")
        {
            Database.SetInitializer<MyDBContext>(new DropCreateDatabaseIfModelChanges<MyDBContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Configurations.AddFromAssembly(typeof(MyDBContext).Assembly);

        }

        //public virtual DbSet<TaskInstanceEntity> TaskInstanceEntities { get; set; }

        public virtual DbSet<PingResultEntity> PingResultEntities { get; set; }
        public virtual DbSet<HongBaoUrlEntity> HongBaoUrlEntities { get; set; }
        public virtual DbSet<UsedUrlEntity> UsedUrlEntities { get; set; }
    }
}
