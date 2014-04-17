using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WishingTree.Model;
using DataLibraries;

namespace AjaxFrame
{
    public class AjaxService : BaseAJAXAction
    {
        public List<string> idlist = new List<string>();

        public object GoTree(object msg, object istree)
        {
            IDBOperate oper = Factory.Da.CreateOperate();

            TreeModel model = new TreeModel();
            try
            {
                model.Id = Guid.NewGuid().ToString("N");
                model.Content = msg.ToString();
                model.IsTree = Convert.ToBoolean(istree);
                oper.Insere(model);
            }
            catch
            {
                return false;
            }
            idlist.Add(model.Id);
            return true;
        }

        public TreeModel GetNewData()
        {
            IDBOperate oper = Factory.Da.CreateOperate();
            TreeModel model = null;
            if (idlist.Count == default(int))
            {
                idlist = oper.QueryList<TreeModel>("select * from Tree where IsTree=0").Select(x => x.Id).ToList<string>();
            }
            Random rnd = new Random();
            int count = rnd.Next(0, idlist.Count);
            model = oper.Get<TreeModel>(idlist[count]);

            return model;
        }

        public IList<TreeModel> GetAll()
        {
            IDBOperate oper = Factory.Da.CreateOperate();
            return oper.QueryList<TreeModel>("select * from Tree");
        }
    }
}