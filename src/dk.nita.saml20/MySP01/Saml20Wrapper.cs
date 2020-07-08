using dk.nita.saml20.protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Saml20Wrapper
{
    public class Saml20SignonHandlerWrapper : IHttpHandler, IRequiresSessionState
    {
        private Saml20SignonHandler _handler;

        public Saml20SignonHandlerWrapper()
        {
            _handler = new Saml20SignonHandler();
        }

        public int MyProperty { get; set; }


        public bool IsReusable { 
            get { return _handler.IsReusable; } 
        }

        public void ProcessRequest(HttpContext context)
        {
            _handler.ProcessRequest(context);
        }
    }
}
