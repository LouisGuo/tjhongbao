using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {

            var service = new PingResultService();
            service.Add(new WebApplication4.PingResultEntity()
            {
                Id = Guid.NewGuid(),
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                SuccessSum = 0,
                FailedSum = 0,
                Ip = string.Empty,
                PingSuccess = true,
                ServerName = "www.baidu.com"
            });

            var hongbaoService = new HongBaoUrlService();
            hongbaoService.Add(new HongBaoUrlEntity
            {
                Id = Guid.NewGuid(),
                Url = "http://activity.waimai.meituan.com/coupon/channel/CC25963E21354994A045E7B473A11A4A?urlKey=E255576C656F405191D2FA7EFEAE4BB7",
                CreatorId = "test",
                CreateTime = DateTime.Now,
                PlateformType = PlateformType.MeiTuan,
                UsedTimes = 0
            });
            var result = hongbaoService.GetByUserId("test", PlateformType.MeiTuan);

            var test = hongbaoService.GetByUrl("test");

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}