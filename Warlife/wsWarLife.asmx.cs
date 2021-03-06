﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Warlife;

namespace Warlife
{
    /// <summary>
    /// Summary description for wsWarLife
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class wsWarLife : System.Web.Services.WebService
    {

        [WebMethod]        
        public string SetNewUser(string sUserName , string sPassword)
        {
            string sResponseMessage = "";
            wsObjects.User wUser = new wsObjects.User();
            DateTime dtCreationDate = new DateTime();
            dtCreationDate = DateTime.Now;
            wUser.SetNewUser(sUserName, sPassword, dtCreationDate, out sResponseMessage);
            return sResponseMessage;

        }

        [WebMethod]
        public string LogIn(string sUserName, string sPassword)
        {
            string sResponseMessage = "";
            wsObjects.User wUser = new wsObjects.User();
            wUser.LogIn(sUserName, sPassword, out sResponseMessage);
            return sResponseMessage;
        }
  
            
    }
}
