using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WishingTree.Model;
using DataLibraries;

namespace WishingTreeService
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IDBOperate oper = Factory.Da.CreateOperate();

            TreeModel model = new TreeModel();
            model.Id = Guid.NewGuid().ToString("N");
            model.Content = "my second";
            model.IsText = true;
            oper.Insere(model);
        }
    }
}