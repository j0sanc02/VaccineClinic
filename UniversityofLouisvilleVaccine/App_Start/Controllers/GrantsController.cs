using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityofLouisvilleVaccine.Controllers
{
    [Authorize(Roles = "Admin, Executive, ProgramStaff, Researcher")]
    public class GrantsController : Controller
    {
        //
        // GET: /Grants/
        public ActionResult Index()
        {
            return View();
        }
	}
}