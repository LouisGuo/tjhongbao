using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    public class UsedUrlEntity : EntityBase
    {
        public String RecieverUserId { get; set; }

        public Guid HongBaoUrlId { get; set; }
        
    }
}