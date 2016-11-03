using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class PingResultService : ServiceBase<PingResultEntity>
    {
        public void PingAllServer()
        {
            var serverList = this.GetAll();
            foreach (var server in serverList)
            {
                var pingResult = true;//IpHelper.PingIp(server.Ip);
                server.PingSuccess = pingResult;
                server.UpdateTime = DateTime.Now;
                if (pingResult)
                {
                    server.SuccessSum++;
                }
                else
                {
                    server.FailedSum++;
                }
                this.Update(server);
            }
        }
    }
}
