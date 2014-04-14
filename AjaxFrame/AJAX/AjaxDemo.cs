using System;
using System.Collections.Generic;
using System.Web;

namespace AjaxFrame
{
    public class AjaxDemo : BaseAJAXAction
    {
        public string ajaxtest(object a, object cn, object s)
        {
            return Session["a"].ToString();
        }

        public List<string> backList()
        {
            List<string> list = new List<string>() { "测试1", "测试2", "测试3", "测试4", "测试5", "测试6", "测试7" };
            Session["a"] = "first test!";
            return list;
        }
    }
}
