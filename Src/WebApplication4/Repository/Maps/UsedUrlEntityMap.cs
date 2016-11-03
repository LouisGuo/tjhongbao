using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4 
{
    public class UsedUrlEntityMap : EntityMapBase<UsedUrlEntity>
    {
        public UsedUrlEntityMap()
        {
            ToTable("UsedUrls");
        }
    }
}