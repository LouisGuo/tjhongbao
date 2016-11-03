using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class PingResultEntity : EntityBase
    {
        public String ServerName { get; set; }

        public String Ip { get; set; }

        public DateTime UpdateTime { get; set; }

        public Int64 SuccessSum { get; set; }

        public Int64 FailedSum { get; set; }

        public Boolean? PingSuccess { get; set; }
    }
}
