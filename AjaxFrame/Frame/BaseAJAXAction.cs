using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace AjaxFrame
{
    public class BaseAJAXAction : IRequiresSessionState
    {
        public HttpRequest Request {
            get {
                return HttpContext.Current.Request;
            }
        }

        public HttpResponse Response {
            get {
                return HttpContext.Current.Response;
            }
        }

        public HttpSessionState Session {
            get {
                return HttpContext.Current.Session;
            }
        }
    }
}