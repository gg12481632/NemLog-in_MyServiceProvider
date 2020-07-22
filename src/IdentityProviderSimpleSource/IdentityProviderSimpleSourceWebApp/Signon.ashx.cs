using IdentityProviderSimpleSourceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace IdentityProviderSimpleSourceWebApp
{
    /// <summary>
    /// Summary description for Signon
    /// </summary>
    public class Signon : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            string SAMLRequest = context.Request.Params["SAMLRequest"];
            string SigAlg = context.Request.Params["SigAlg"];
            string Signature = context.Request.Params["Signature"];

            //string SAMLRequest = "lZJfa8IwFMXfB%2FsOIe82aax%2FGlpF5ouwwdCxh72F5jrD2kR7U%2FHjL1G7jcGEvebknPO7l1vMT01NjtCicbakacLpfHZ%2FVxxSuej8zq7h0AF6slqW1OjRMNfjVEyHW8gykXGl9VBDrkZ8O%2BHTfEzJa58kQhJZIXawsuiV9eGJCz7gk4EQL3wqMy6zcZJOuMhy8UbJMtQYq%2FzZvfN%2Bj5IxZxyqph5oaJzR%2B0R%2FSME5T9nGvFtnE4W7U6x5VojmCCXdqhqBkjCURXlIS9q1VjqFBqVVDaD0ldwsnh5l4JP71nlXuZqGiQkpzrTtxXvbGNqgjaR01pNGzKTHteADasEuiZf0B2e1iR78Z0N0B%2F%2Bi0wZsBeuwp9ZUUbtKP8TbOF%2B%2FrpHsr8yCfdPGa2C%2FzmH2CQ%3D%3D";
            //string SigAlg = "http%3A%2F%2Fwww.w3.org%2F2001%2F04%2Fxmldsig-more%23rsa-sha512";
            //string Signature = "J3iUDsHdwR1t0HjI7i57zx04gEz6R6XtHuus%2f45LE%2f1BqLNZqJInueXAWHP7JiOlQPdtg%2b09WRp3lU5XLo5OHbeYx003yGywV3JTeQ7eosyxZoZ7LDfW9WRQtytZitljzLbdBIccH4iLvtOTW9v5ZzI7ohMG6OHWj9cs%2fzJ%2f3I1jsCw2vnJE2TUZ0riy15FsopK9toho7z7mwksl1lChE%2bDGa7SJF49NJl68Za4FUNA2u2sqfxCDVsott0N3ZVzKiZ52NJ%2fP%2bKrXsN7bpLgeyL9CfT4Pe7dZzAFdYxPikq3P31UJmbRGtAVzCKXmQ2S3zFZp8R2DnI6p4N00cjeloQ%3d%3d";

            SAMLRequest = DecodeUrlString(SAMLRequest);
            SigAlg = DecodeUrlString(SigAlg);
            AuthRequestSubset spMetaData = BusinessLogic.SignIn(SAMLRequest, SigAlg, Signature);

            HttpContext.Current.Session["authenticationrequest"] = spMetaData;
            HttpContext.Current.Server.Transfer("SignonForm.aspx");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private static string DecodeUrlString(string url)
        {
            string newUrl;
            while ((newUrl = Uri.UnescapeDataString(url)) != url)
                url = newUrl;
            return newUrl;
        }

    }
}