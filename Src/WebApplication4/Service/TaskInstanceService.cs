//using CSharpUtil.Worker;
//using RMOS.Data;
//using RMOS.Data.Entities;
//using RMOS.Domain.Extensions;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;

//namespace RMOS.Domain.Services
//{
//    public class TaskInstanceService : ServiceBase<TaskInstanceEntity>, IWorkerAccessor
//    {
//        [TaskInstance(IsTimer = true, IntervalSeconds = 10, Name = "GetAllTaskInstance", ReRunOnFault = true, RetryTimesOnError = 3)]
//        public override List<TaskInstanceEntity> GetAll()
//        {
//            return base.GetAll();
//        }

//        public void Fault(TaskInstance task)
//        {
//            using (var accessorDBContext = new RMOSDBContext())
//            {
//                var taskInstanceEntity = task.To();
//                accessorDBContext.TaskInstanceEntities.Attach(taskInstanceEntity);
//                accessorDBContext.Entry<TaskInstanceEntity>(taskInstanceEntity).State = EntityState.Modified;
//                taskInstanceEntity.UpdateTime = DateTime.Now;
//                taskInstanceEntity.Status = TaskStatus.Faulted;
//                accessorDBContext.SaveChanges();
//            }
//        }

//        public void Finish(TaskInstance task)
//        {
//            using (var accessorDBContext = new RMOSDBContext())
//            {
//                var taskInstanceEntity = task.To();
//                accessorDBContext.TaskInstanceEntities.Attach(taskInstanceEntity);
//                accessorDBContext.Entry<TaskInstanceEntity>(taskInstanceEntity).State = EntityState.Modified;
//                taskInstanceEntity.UpdateTime = DateTime.Now;
//                taskInstanceEntity.Status = TaskStatus.RanToCompletion;
//                accessorDBContext.SaveChanges();
//            }
//        }

//        public void MakeWaiting(TaskInstance task)
//        {
//            using (var accessorDBContext = new RMOSDBContext())
//            {
//                var taskInstanceEntity = task.To();
//                accessorDBContext.TaskInstanceEntities.Attach(taskInstanceEntity);
//                accessorDBContext.Entry<TaskInstanceEntity>(taskInstanceEntity).State = EntityState.Modified;
//                taskInstanceEntity.UpdateTime = DateTime.Now;
//                taskInstanceEntity.Status = TaskStatus.WaitingToRun;
//                accessorDBContext.SaveChanges();
//            }
//        }

//        public TaskInstance Peek()
//        {
//            var result = default(TaskInstance);
//            using (var accessorDBContext = new RMOSDBContext())
//            {
//                var taskInstanceEntity = (from t in accessorDBContext.TaskInstanceEntities
//                                          where t.Status == TaskStatus.Created || (t.Status == TaskStatus.WaitingToRun && t.NextTimeToRun <= DateTime.Now)
//                                          orderby t.Priority descending, t.UpdateTime descending
//                                          select t).FirstOrDefault();
//                if (taskInstanceEntity != null)
//                {
//                    taskInstanceEntity.Status = TaskStatus.Running;
//                    taskInstanceEntity.UpdateTime = DateTime.Now;
//                    accessorDBContext.SaveChanges();
//                    result = taskInstanceEntity.To();
//                }
//            }
//            return result;
//        }

//        public TaskInstance PeekUnfinshed()
//        {
//            var expireTime = DateTime.Now.AddHours(-12);
//            var result = default(TaskInstance);
//            using (var accessorDBContext = new RMOSDBContext())
//            {
//                var taskInstanceEntity = (from t in accessorDBContext.TaskInstanceEntities
//                                          where t.Status == TaskStatus.Running && t.UpdateTime < expireTime
//                                          orderby t.Priority descending, t.UpdateTime descending
//                                          select t).FirstOrDefault();
//                if (taskInstanceEntity != null)
//                {
//                    taskInstanceEntity.Status = TaskStatus.Running;
//                    taskInstanceEntity.UpdateTime = DateTime.Now;
//                    accessorDBContext.SaveChanges();
//                    result = taskInstanceEntity.To();
//                }
//            }
//            return result;
//        }

//        public void Requeue(TaskInstance task)
//        {
//            using (var accessorDBContext = new RMOSDBContext())
//            {
//                var taskInstanceEntity = task.To();
//                accessorDBContext.TaskInstanceEntities.Attach(taskInstanceEntity);
//                accessorDBContext.Entry<TaskInstanceEntity>(taskInstanceEntity).State = EntityState.Modified;
//                taskInstanceEntity.UpdateTime = DateTime.Now;
//                taskInstanceEntity.Status = CSharpUtil.Worker.TaskStatus.Created;
//                accessorDBContext.SaveChanges();
//            }
//        }
//    }
//}
