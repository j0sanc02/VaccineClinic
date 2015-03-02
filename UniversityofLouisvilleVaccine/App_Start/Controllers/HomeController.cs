using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult GetEvents(double start, double end)
        {
            var fromDate = ConvertFromUnixTimestamp(start);
            var toDate = ConvertFromUnixTimestamp(end);

            //Get the events
            //You may get from the repository also
            var eventList = GetEvents();

            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        private List<Event> GetEvents()
        {
            List<Event> eventList = new List<Event>();
            EventDBContext db = new EventDBContext();

            foreach (var vs in db.Events)
            {
                DateTime start = Convert.ToDateTime(vs.start).AddHours(vs.hour).AddMinutes(vs.min);
                DateTime endtime = start.AddMinutes(15);

                Event newEvent = new Event
                {

                    id = vs.id,
                    title = vs.title,
                    start = start.ToString(),
                    end = endtime.ToString(),
                    allDay = false
                };

                eventList.Add(newEvent);
            }


            return eventList;
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

    }
}