//using CSharpUtil.Worker;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace RMOS.Data.Entities
//{
//    public class TaskInstanceEntity : EntityBase
//    {
//        public String Name { get; set; }

//        public String Type { get; set; }

//        public String Method { get; set; }

//        public Byte[] Params { get; set; }

//        public DateTime UpdateTime { get; set; }

//        public DateTime NextTimeToRun { get { return this.UpdateTime.AddSeconds(this.IntervalSeconds); } set { } }

//        public Boolean IsTimer { get; set; }

//        public int RetryTimesOnError { get; set; }

//        public bool ReRunOnFault { get; set; }

//        public TaskStatus Status { get; set; }

//        public String Message { get; set; }

//        public TaskPriority Priority { get; set; }

//        public Int64 IntervalSeconds { get; set; }
//    }
//}
