/*Donate, Assignment 6
 *Add a controller to handle donations.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommAsst17in18for172.Models;

namespace CommAsst17in18for172.Controllers
{
    public class DonationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        Message argMessage = new Message();
        // GET: Donation
        public ActionResult Index()
        {
            /*Donate, Assignment 6
             *You should check to make sure the user is logged in.
             *You can do this by checking to see if the Session variable is
             *null or not. Null means they are not logged in.*/
            if (Session["sessClientKey"] == null)
            {
                argMessage.MessageText = "You must be authenticated to " +
                    "donate to the Community Assist Project";
                /*Donate, Assignment 6
                 *If they are not logged in, you should redirect them to a
                 *result page where it tells them they must be logged in*/
                return RedirectToAction("Result", argMessage);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Amount")]Donate donate)
        {
            /*Donate, Assignment 6
             *if they are logged in, write the amount and the personkey and
             *the date and set the guid for a new Donation Class*/
            Donation donation = new Donation();
            donation.DonationAmount = donate.Amount;
            donation.PersonKey = Session["sessClientKey"].GetHashCode();
            donation.DonationDate = DateTime.Now;
            donation.DonationConfirmationCode = Guid.NewGuid();

            db.Donations.Add(donation);
            /*Donate, Assignment 6
             *Save the changes to the database.*/
            db.SaveChanges();

            /*Donate, Assignment 6
             *The result page should now thank them for their donation.*/
            argMessage.MessageText = "Thank for your donation to the " +
                "Community Assist Project";
            return View("Result", argMessage);
        }

        public ActionResult Result(Message paraMessage)
        {
            return View(paraMessage);
        }
    }
}