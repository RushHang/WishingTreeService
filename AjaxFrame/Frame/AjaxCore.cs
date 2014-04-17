using System.Web;
using System.Web.SessionState;
using System.Text;
using System.IO;
using System;
using System.Runtime.Serialization.Json;


namespace AjaxFrame
{
    public class AjaxCore : IHttpHandler, IRequiresSessionState
    {
        #region IHttpHandler 成员

        public AjaxMould ajaxMould { get; set; }

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            object result;
            switch (ajaxMould.Parameters.Length)
            {
                case 0:
                    result = ajaxMould.ExecuteDelegate();
                    break;
                case 1:
                    result = ajaxMould.ExecuteDelegate(GetParameterByOrder(0));
                    break;
                case 2:
                    result = ajaxMould.ExecuteDelegate(GetParameterByOrder(0), GetParameterByOrder(1));
                    break;
                case 3:
                    result = ajaxMould.ExecuteDelegate(GetParameterByOrder(0), GetParameterByOrder(1), GetParameterByOrder(2));
                    break;
                case 4:
                    result = ajaxMould.ExecuteDelegate(GetParameterByOrder(0), GetParameterByOrder(1), GetParameterByOrder(2), GetParameterByOrder(3));
                    break;
                case 5:
                    result = ajaxMould.ExecuteDelegate(GetParameterByOrder(0), GetParameterByOrder(1), GetParameterByOrder(2), GetParameterByOrder(3), GetParameterByOrder(4));
                    break;
                case 6:
                    result = ajaxMould.ExecuteDelegate(GetParameterByOrder(0), GetParameterByOrder(1), GetParameterByOrder(2), GetParameterByOrder(3), GetParameterByOrder(4), GetParameterByOrder(5));
                    break;
                default:
                    result = "";
                    throw new Exception("参数量超过了设定的程度6！请添加新的委托");
            }
            if (ajaxMould.IsJson)
            {
                result = JsonSerializer(result);
                context.Response.ContentType = "application/json; charset=utf-8";
            }
            context.Response.Write(result);
        }

        #endregion

        /// <summary>
        /// 从get和post里面找符合名称的参数，如有多个以","分开
        /// </summary>
        /// <param name="nmb"></param>
        /// <returns></returns>
        public object GetParameterByOrder(int nmb)
        {
            return HttpContext.Current.Request[ajaxMould.Parameters[nmb].ToString()];
        }

        public static string JsonSerializer(object t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(t.GetType());
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }
    }

    public class AjaxMould
    {
        public AjaxMould()
        {
            this.IsJson = false;
            _parameters = new object[0];
        }

        private string _className;

        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName
        {
            get
            {
                return _className;
            }
            set
            {
                _className = value;
            }
        }

        private string _methodName;

        /// <summary>
        /// 方法名
        /// </summary>
        public string MethodName
        {
            get
            {
                return _methodName;
            }
            set
            {
                _methodName = value;
            }
        }

        private object[] _parameters;
        /// <summary>
        /// 参数名列表
        /// </summary>
        public object[] Parameters
        {
            get
            {
                return _parameters;
            }
            set
            {
                _parameters = value;
            }
        }

        public object ExecuteDelegate()
        {
            return Delegate0();
        }

        public object ExecuteDelegate(object arg1)
        {
            return Delegate1(arg1);
        }

        public object ExecuteDelegate(object arg1, object arg2)
        {
            return Delegate2(arg1, arg2);
        }

        public object ExecuteDelegate(object arg1, object arg2, object arg3)
        {
            return Delegate3(arg1, arg2, arg3);
        }

        public object ExecuteDelegate(object arg1, object arg2, object arg3, object arg4)
        {
            return Delegate4(arg1, arg2, arg3, arg4);
        }

        public object ExecuteDelegate(object arg1, object arg2, object arg3, object arg4, object arg5)
        {
            return Delegate5(arg1, arg2, arg3, arg4, arg5);
        }

        public object ExecuteDelegate(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6)
        {
            return Delegate6(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        /// <summary>
        /// 是否为json数据，默认为false
        /// </summary>
        public bool IsJson { get; set; }
        /// <summary>
        /// 执行委托事件（有返回值）
        /// </summary>
        public event AjaxDelegate<object> Delegate0;

        public event AjaxDelegate<object, object> Delegate1;

        public event AjaxDelegate<object, object, object> Delegate2;

        public event AjaxDelegate<object, object, object, object> Delegate3;

        public event AjaxDelegate<object, object, object, object, object> Delegate4;

        public event AjaxDelegate<object, object, object, object, object, object> Delegate5;

        public event AjaxDelegate<object, object, object, object, object, object, object> Delegate6;
    }
    //一系列委托
    public delegate TResult AjaxDelegate<TResult>();

    public delegate TResult AjaxDelegate<A1, TResult>(A1 arg1);

    public delegate TResult AjaxDelegate<A1, A2, TResult>(A1 arg1, A2 arg2);

    public delegate TResult AjaxDelegate<A1, A2, A3, TResult>(A1 arg1, A2 arg2, A3 arg3);

    public delegate TResult AjaxDelegate<A1, A2, A3, A4, TResult>(A1 arg1, A2 arg2, A3 arg3, A4 arg4);

    public delegate TResult AjaxDelegate<A1, A2, A3, A4, A5, TResult>(A1 arg1, A2 arg2, A3 arg3, A4 arg4, A5 arg5);

    public delegate TResult AjaxDelegate<A1, A2, A3, A4, A5, A6, TResult>(A1 arg1, A2 arg2, A3 arg3, A4 arg4, A5 arg5, A6 arg6);

}
