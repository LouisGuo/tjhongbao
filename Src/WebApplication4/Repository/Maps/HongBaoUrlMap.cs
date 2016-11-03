using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    public class HongBaoUrlMap : EntityMapBase<HongBaoUrlEntity>
    {
        public HongBaoUrlMap()
        {
            ToTable("HongBaoUrls");
        }
    }
}