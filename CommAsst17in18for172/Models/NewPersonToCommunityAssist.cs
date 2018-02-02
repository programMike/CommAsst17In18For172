/*Registration * 1 Add another model to the model classes. I would call
 *it NewPerson. It will contain the fields for Person and PersonAddress.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommAsst17in18for172.Models
{
    public class NewPersonToCommunityAssist
    {
        //fields from Person table, relvent
        public string PersonLastName { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonEmail { get; set; }
        public string PersonPrimaryPhone { get; set; }
        public string PersonPassword { get; set; }
        public string PersonDateAdded { get; set; }

        //fields from PersonAddress table, relvent
        public string PersonAddressApt { get; set; }
        public string PersonAddressStreet { get; set; }
        public string PersonAddressCity { get; set; }
        public string PersonAddressState { get; set; }
        public string PersonAddressPostal { get; set; }
        public string PersonAddressDateAdded { get; set; }
    }
}