using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    public class HongBaoUrlEntity : EntityBase
    {
        public String Url { get; set; }

        public String OrigionUrl { get; set; }

        public String CreatorId { get; set; }

        public Int32 UsedTimes { get; set; }

        public PlateformType PlateformType { get; set; }
    }

    public enum PlateformType
    {
        MeiTuan = 0,
        Eleme = 1,
        Baidu = 2
    }
}