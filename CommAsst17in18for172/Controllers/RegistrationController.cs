/*Registration * 3 Once you have added the model classes,
 *add a new empty controller.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Registration * 4 Add a using statement to access the models
using CommAsst17in18for172.Models;

namespace CommAsst17in18for172.Controllers
{
    public class RegistrationController : Controller
    {
        /*Registration * 5 Make two index methods, on that simply returns
         *the view, and one with the [HttpPost] directive that takes a
         *NewPerson class as an parameter.*/
        
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(NewPersonToCommunityAssist newPersonToCommAsst)
        {
            //connect with the data entities
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            //message object utilized if a http post was detected
            Message message = new Message();

            /*Registration * 6 Use the stored procedure usp_Register and pass
             *the fields from the class to the stored procedure (they must 
             *all be there in the right order)*/
            int storeRegisterAsConfirmInt = db.usp_Register(
                newPersonToCommAsst.PersonLastName, 
                newPersonToCommAsst.PersonFirstName,
                newPersonToCommAsst.PersonEmail,
                newPersonToCommAsst.PersonPassword,
                newPersonToCommAsst.PersonAddressApt,
                newPersonToCommAsst.PersonAddressStreet,
                newPersonToCommAsst.PersonAddressCity,
                newPersonToCommAsst.PersonAddressState,
                newPersonToCommAsst.PersonAddressPostal,
                newPersonToCommAsst.PersonPrimaryPhone);

            /*Registration * 7 The stored procedure returns -1 if it fails. if
             *it doesn't fail, return a message to a results view that says
             *"Thanks for registering."*/
            message.MessageText = "Thanks for registering.";

            if (storeRegisterAsConfirmInt == -1)
            {
                /*Registration * 8 If it does return -1 the message should
                 *read "Sorry, but something seems to have gone wrong with
                 *the registration."*/
                message.MessageText = "Sorry, but something seems to have" +
                    "gone wrong with the registration.";
                return View("Result", message);
            }

            return View("Result", message);
        }
    }
}