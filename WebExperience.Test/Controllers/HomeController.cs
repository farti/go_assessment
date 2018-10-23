using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExperience.Test.Models;

namespace WebExperience.Test.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var asset = _context.Assets.SingleOrDefault(x => x.Id == id);

            if (asset == null)
            {
                return HttpNotFound();
            }

            return View(asset);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}