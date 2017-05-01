using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Doku;
using System.Diagnostics;

namespace doku_library.example_payment
{
    public partial class merchant_va_example : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Doku_Initiate.sharedKey = "k8UhY5t4RF4e"; //local
                //Doku_Initiate.sharedKey = "aKh4dSX72d6C";//luna
                Doku_Initiate.mallId = Request.Form["mall_id"];

                #region PREDATA
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("amount", Request.Form["amount"]);
                param.Add("invoice", Request.Form["trans_id"]);
                param.Add("currency", Request.Form["currency"]);

                string words = Library.doCreateWords(param);

                Dictionary<string, string> customer = new Dictionary<string, string>();
                customer.Add("name", "TEST NAME");
                customer.Add("data_phone", "08121111111");
                customer.Add("data_email", "test@test.com");
                customer.Add("data_address", "bojong gede #1 08/01");
                string JSONCustomer = Helper.DictionaryToJson(customer);

                Dictionary<string, object> dataPayment = new Dictionary<string, object>();
                dataPayment.Add("req_mall_id", Request.Form["mall_id"]);
                dataPayment.Add("req_chain_merchant", Request.Form["chain_merchant"]);
                dataPayment.Add("req_amount", param["amount"]);
                dataPayment.Add("req_words", words);
                dataPayment.Add("req_trans_id_merchant", Request.Form["trans_id"]);
                dataPayment.Add("req_purchase_amount", param["amount"]);
                dataPayment.Add("req_request_date_time", Helper.getDate());
                dataPayment.Add("req_session_id", Helper.GetSHA1HashData(Helper.getDate()));
                dataPayment.Add("req_email", customer["data_email"]);
                dataPayment.Add("req_name", customer["name"]);
                #endregion

                string JSONData = Helper.DictionaryToJson(dataPayment);
                Debug.Write(JSONData);

                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("data", JSONData);

                string response = Doku_Api.doGeneratePaycode(data);

                dynamic results = Newtonsoft.Json.JsonConvert.DeserializeObject(response);
                if (results != null)
                {
                    var code = results.res_response_code;
                    if (code != null && code.Value == "0000")
                    {
                        Literal1.Text = "GENERATE SUCCESS -- ";
                    }
                    else
                    {
                        Literal1.Text = "GENERATE FAILED -- ";
                    }

                    Literal1.Text += results;
                }
                else
                {
                    Literal1.Text = "NO SERVER RESPONSE -- ";
                }
            }
        }
    }
}