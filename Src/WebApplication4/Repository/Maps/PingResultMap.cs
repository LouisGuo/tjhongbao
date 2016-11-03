using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4
{
    class PingResultMap : EntityMapBase<PingResultEntity>
    {
        public PingResultMap()
        {
            ToTable("PingResults");
            Property(p => p.ServerName).HasMaxLength(255);
            Property(p => p.Ip).HasMaxLength(255).IsRequired();
            Property(p => p.UpdateTime).IsRequired();
            Property(p => p.SuccessSum).IsRequired();
            Property(p => p.FailedSum).IsRequired();
            Property(p => p.PingSuccess).IsOptional();
        }
    }
}
