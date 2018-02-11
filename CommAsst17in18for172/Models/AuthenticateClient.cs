/*Logging in, Assignment 5
 *establish a data class to authenticate a client to the
 *Community Assist project */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommAsst17in18for172.Models
{
    public class AuthenticateClient
    {
        //empty constructor
        public AuthenticateClient () { }

        //overider constructor
        public AuthenticateClient (string paraClientEmail, 
            string paraClientPassword)
        {
            ClientEmail = paraClientEmail;
            ClientPassword = paraClientPassword;
        }

        public string ClientEmail { set; get; }
        public string ClientPassword { set; get; }
    }
}