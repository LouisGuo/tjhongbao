//using RMOS.Data.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RMOS.Data.Maps
//{
//    class TaskInstanceMap : EntityMapBase<TaskInstanceEntity>
//    {
//        public TaskInstanceMap()
//        {
//            ToTable("TaskInstances");
//            Property(p => p.Name).IsUnicode().HasMaxLength(255).IsOptional();
//            Property(p => p.Type).IsUnicode().HasMaxLength(1000).IsRequired();
//            Property(p => p.Method).IsUnicode().HasMaxLength(255).IsRequired();
//            Property(p => p.Params).IsOptional().IsMaxLength();
//            Property(p => p.UpdateTime).HasColumnType("TimeStamp").IsRequired();
//            Property(p => p.NextTimeToRun).HasColumnType("TimeStamp").IsRequired();
//            Property(p => p.IsTimer).IsRequired();
//            Property(p => p.RetryTimesOnError).IsRequired();
//            Property(p => p.ReRunOnFault).IsRequired();
//            Property(p => p.Status).IsRequired();
//            Property(p => p.Message).IsOptional().IsMaxLength();
//            Property(p => p.Priority).IsRequired();
//            Property(p => p.IntervalSeconds).IsRequired();
//        }
//    }
//}
