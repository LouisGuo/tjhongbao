using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class EntityBase
    {
        public EntityBase()
        {
        }

        public Guid Id { get; set; }

        public DateTime CreateTime { get; set; }

    }
}
