using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//2 * Add a using reference to the project models
using CommAsst17in18for172.Models;


//1 * Find the home controller:
//i found it!  programming god 2 b

namespace CommAsst17in18for172.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();

            //3 * Modify the index method to create a list of objects
            //4 * Have that list returned to the view        
            return View(db.GrantTypes.ToList());
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
    }
}