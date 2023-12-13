using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeclarationDeVol.Models;

namespace DeclarationDeVol.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var data = GetChartData();
            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private List<Models.ChartDataViewModel> GetChartData()
        {
            using (var context = new Models.RQVEntities1())
            {
                var chartData = context.Declaration
                    .GroupBy(d => d.place)
                    .Select(group => new ChartDataViewModel
                    {
                        Location = group.Key,
                        ObjectCount = group.Count()
                    })
                    .ToList();

                return chartData;
            }
        }
    }
}