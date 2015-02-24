using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityofLouisvilleVaccine.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        //
        // GET: /Schedule/
        public ActionResult Index()
        {
            return View();
        }
	}
}