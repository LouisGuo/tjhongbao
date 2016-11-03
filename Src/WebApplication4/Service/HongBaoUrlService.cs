using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    public class HongBaoUrlService : ServiceBase<HongBaoUrlEntity>
    {
        public HongBaoUrlEntity GetByUserId(String recieveUserId, PlateformType plateformType)
        {
            using (var context = new MyDBContext())
            {
                var sql = @"select top 1 * from HongBaoUrls 
                            where UsedTimes < 10 and PlateformType = @PlateformType
                                  and Id not in (select distinct HongBaoUrlId 
                                                 from UsedUrls 
                                                 where RecieverUserId = @userId)
                            order by CreateTime desc";
                var param = new SqlParameter[]
                {
                    new SqlParameter("@PlateformType", (int)plateformType),
                    new SqlParameter("@userId", recieveUserId),
                };
                var result = context.Database.SqlQuery<HongBaoUrlEntity>(sql, param).FirstOrDefault();
                if (result != null)
                {
                    result.UsedTimes++;
                    context.Entry(result).State = System.Data.Entity.EntityState.Modified;
                    var usedUrl = new UsedUrlEntity
                    {
                        Id = Guid.NewGuid(),
                        CreateTime = DateTime.Now,
                        RecieverUserId = recieveUserId,
                        HongBaoUrlId = result.Id
                    };
                    context.UsedUrlEntities.Add(usedUrl);
                    context.SaveChanges();
                }
                return result;
            }
        }

        public HongBaoUrlEntity GetByUrl(String url)
        {
            using (var context = new MyDBContext())
            {
                return (from h in context.HongBaoUrlEntities
                        where h.Url.Equals(url)
                        select h).FirstOrDefault();
            }
        }
    }
}