/*Logging in, Assignment 5
 *For this assignment, we will add a login controller, and allow people who 
 *have registered to log in so they can donate or apply for assistance.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//access the project models
using CommAsst17in18for172.Models;

namespace CommAsst17in18for172.Controllers
{
    public class AuthenticateController : Controller
    {
        // GET: Authenticate
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(
            //bind form values to the class preceeding square brackets
            [Bind(Include = "ClientEmail, ClientPassword")]
            AuthenticateClient authClient)
        {
            Message argMessage = new Message();
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            /*Logging In
             *For the login validation we will use the built in stored procedure
             *usp_login which takes a username (email) and a password.*/
            int verifyAuthentication = db.usp_Login( authClient.ClientEmail, 
                authClient.ClientPassword );

            /*If the validation fails (the stored procedure returns a -1 if it
             *fails), the Result page should say something like Validation 
             *failed, please try again or register if you have not done so yet.*/
            if ( verifyAuthentication != -1 )
            {
                var personKey = ( from r in db.People
                               where r.PersonEmail.Equals
                               ( authClient.ClientEmail )
                               select r.PersonKey ).FirstOrDefault();
                int clientKey = (int)personKey;

                Session["sessClientKey"] = clientKey;

                argMessage.MessageText = "Thank you for verifying creditials " +
                    "of e-mail account: " + authClient.ClientEmail + ".";

                return RedirectToAction("Result", argMessage);
            }
            argMessage.MessageText = "Invaild authentication credentials " +
                "please try again or register if you have not done so yet.";

            return View("Result", argMessage);
        }

        public ActionResult Result( Message paraMessage )
        {
            return View( paraMessage );
        }
    }
}