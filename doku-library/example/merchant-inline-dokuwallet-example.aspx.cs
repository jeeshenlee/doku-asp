using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Doku;

namespace doku_library.example
{
    public partial class merchant_inline_dokuwallet_example : System.Web.UI.Page
    {
        public string words = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Doku_Initiate.sharedKey = "k8UhY5t4RF4e"; //local
                //Doku_Initiate.sharedKey = "aKh4dSX72d6C";//luna
                Doku_Initiate.mallId = Request.Form["mall_id"];

                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("amount", Request.Form["amount"]);
                param.Add("invoice", Request.Form["trans_id"]);
                param.Add("currency", Request.Form["currency"]);
                words = Library.doCreateWords(param);
            }
        }
    }
}