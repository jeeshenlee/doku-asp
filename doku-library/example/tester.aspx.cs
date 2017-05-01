using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Doku;
using System.Diagnostics;
using Newtonsoft.Json;

namespace doku_library.example
{
    public partial class tester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                frmTester.Action = "merchant-example.aspx";
                string urlBased = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf("/example/"));
                server_url.Value = urlBased + "/example-payment/merchant-example.aspx";
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                trans_id.Value = "invoice_" + unixTimestamp.ToString();
            }
        }
    }
}