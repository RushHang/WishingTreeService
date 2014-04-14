using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WishingTree.Model;
using DataLibraries;

namespace AjaxFrame
{
    public class AjaxService:BaseAJAXAction
    {
        public string GoTree(object msg)
        {
            IDBOperate oper = Factory.Da.CreateOperate();

            TreeModel model = new TreeModel();
            model.Id = Guid.NewGuid().ToString("N");
            model.Content = msg.ToString();
            model.IsText = true;
            oper.Insere(model);

            return "true";
        }
    }
}