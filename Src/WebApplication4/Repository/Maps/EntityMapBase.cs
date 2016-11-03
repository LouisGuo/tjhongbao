using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class EntityMapBase<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        public EntityMapBase()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.CreateTime);
        }
    }
}
