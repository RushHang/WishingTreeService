using System;
using System.Collections.Generic;
using System.Linq;

namespace AjaxFrame
{
    public class AjaxInitialise
    {
        private static List<AjaxMould> _list;

        public static List<AjaxMould> list
        {
            get
            {
                if (_list == null)
                {
                    Initialise();
                }
                return _list;
            }
        }

        /// <summary>
        /// ajax服务端初始化绑定信息
        /// </summary>
        public static void Initialise()
        {
            _list = new List<AjaxMould>();
            AjaxDemo demo = new AjaxDemo();

            #region 测试方案
            AjaxMould mould = new AjaxMould() { ClassName = "AjaxDemo", MethodName = "ajaxtest", Parameters = new object[] { "a", "cn", "s" }, IsJson = false };
            mould.Delegate3 += new AjaxDelegate<object, object, object, object>(demo.ajaxtest);
            _list.Add(mould);

            mould = new AjaxMould() { ClassName = "AjaxDemo", MethodName = "backList", IsJson = true };
            mould.Delegate0 += new AjaxDelegate<object>(demo.backList);
            _list.Add(mould);
            #endregion

            AjaxService aservice = new AjaxService();
            mould = new AjaxMould() { ClassName = "AjaxService", MethodName = "GoTree", IsJson = true, Parameters = new object[] { "msg" } };
            mould.Delegate1 += new AjaxDelegate<object, object>(aservice.GoTree);

            _list.Add(mould);
        }

        public static AjaxMould FindMould(string classname, string methodname)
        {
            try
            {
                return list.Where(x => x.ClassName == classname && x.MethodName == methodname).First();
            }
            catch
            {
                throw new Exception("没有这个ajax的服务端方法！");
            }
        }
    }
}
