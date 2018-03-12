/*Application for Assistance, Assignment 7
 *Create a new controller for Grant Applications.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommAsst17in18for172.Models;

namespace CommAsst17in18for172.Controllers
{
    public class GrantApplicationsController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        Message argMessage = new Message();
        // GET: GrantApplications
        public ActionResult Index()
        {
            /*Application for Assistance, Assignment 7
             *You should make sure the user is logged in. If so,
             *process the grant and then redirect them to a result page
             *that thanks them for applying; if not the result page
             *should direct them to log in or register.*/
            if (Session["sessClientKey"] == null)
            {
                argMessage.MessageText = "To provide a Grant Application " +
                    "you must log in or register, links located above.";
                return RedirectToAction("Result", argMessage);
            }
            /*use of the Viewbag object to contain a listing of the Grant Types
             *as defined within the Grant Type table in field GrantTypeName*/
            ViewBag.GrantTypeKey = new SelectList(db.GrantTypes, "GrantTypeKey", "GrantTypeName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = 
            "GrantTypeKey, GrantApplicationReason, GrantApplicationRequestAmount"
            )]GrantApplication grantApplication)
        {
            /*Application for Assistance, Assignment 7
             *You should be able to use the GrantApplication class already in 
             *the model, but you will need to assign values to some of the fields
             *in the controller...*/
            /*... The personkey field should get the value from the Session variable.*/
            grantApplication.PersonKey = Session["sessClientKey"].GetHashCode();
            /*... The status key field should have the value of "1".*/
            grantApplication.GrantApplicationStatusKey = 1;
            /*... The date should be DateTime.Now*/
            grantApplication.GrantAppicationDate = DateTime.Now;

            db.GrantApplications.Add(grantApplication);
            db.SaveChanges();

            argMessage.MessageText = "Thank for your Grant Application to the " +
                "Community Assist Project";
            return View("Result", argMessage);
        }
        public ActionResult Result(Message paraMessage)
        {
            return View(paraMessage);
        }
    }
}