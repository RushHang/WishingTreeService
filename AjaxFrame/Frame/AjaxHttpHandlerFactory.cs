using System;
using System.Web;

namespace AjaxFrame
{
    public class AjaxHttpHandlerFactory : IHttpHandlerFactory
    {
        #region IHttpHandlerFactory 成员

        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            url = url.Substring(1);
            if (!url.StartsWith("ajax", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("不是有效的ajax请求");
            }
            string[] keys = url.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (keys.Length < 2)
            {
                throw new Exception("不是有效的ajax请求");
            }
            string classname, methodname;
            classname = keys[0];
            methodname = keys[1].Replace(".ashx", "");

            return new AjaxCore() { ajaxMould=AjaxInitialise.FindMould(classname,methodname)};
        }

        public void ReleaseHandler(IHttpHandler handler)
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}
