using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Doku;
using System.Diagnostics;

namespace doku_library.example_payment_mobile
{
    public partial class merchant_example : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Doku_Initiate.sharedKey = "M8Y79iqFvwN4"; //staging
                //Doku_Initiate.sharedKey = "k8UhY5t4RF4e"; //local
                //Doku_Initiate.sharedKey = "aKh4dSX72d6C";//luna
                Doku_Initiate.mallId = "4401";

                dynamic postData = Newtonsoft.Json.JsonConvert.DeserializeObject(Request.Form["data"]);
                if (postData != null)
                {
                    #region PREDATA
                    string token = postData.res_token_id.Value;
                    string pairing_code = postData.res_pairing_code.Value;
                    string invoice_no = postData.res_transaction_id.Value;
                    string amount = postData.res_amount.Value;
                    string device_id = postData.res_device_id.Value;
                    string mobile_number = postData.res_data_mobile_phone.Value;

                    string name = postData.res_data_name.Value;
                    string email = postData.res_data_email.Value;
                    string payment_channel = postData.res_payment_channel.Value;

                    Dictionary<string, string> param = new Dictionary<string, string>();
                    param.Add("amount", amount);
                    param.Add("invoice", invoice_no);
                    param.Add("currency", "360");
                    param.Add("pairing_code", pairing_code);
                    param.Add("token", token);
                    param.Add("device_id", device_id);
                    string words = Library.doCreateWords(param);

                    List<string> basket = new List<string>();
                    basket.Add("sayur");
                    basket.Add(amount);
                    basket.Add("1");
                    basket.Add(amount);
                    basket.Add(";");                 
                    string JSONBasket = Library.formatBasket(Helper.ListToJson(basket));
                    #endregion

                    #region PAYMENT
                    Dictionary<string, object> dataPayment = new Dictionary<string, object>();
                    dataPayment.Add("req_mall_id", "2074");
                    dataPayment.Add("req_chain_merchant", "NA");
                    dataPayment.Add("req_amount", amount);
                    dataPayment.Add("req_words", words);
                    dataPayment.Add("req_purchase_amount", amount);
                    dataPayment.Add("req_trans_id_merchant", invoice_no);
                    dataPayment.Add("req_request_date_time", Helper.getDate());
                    dataPayment.Add("req_currency", "360");
                    dataPayment.Add("req_purchase_currency", "360");
                    dataPayment.Add("req_session_id", Helper.GetSHA1HashData(Helper.getDate()));
                    dataPayment.Add("req_name", name);
                    dataPayment.Add("req_payment_channel", payment_channel);
                    dataPayment.Add("req_basket", JSONBasket);
                    dataPayment.Add("req_email", email);
                    dataPayment.Add("req_token_id", token);
                    dataPayment.Add("req_mobile_phone", mobile_number);
                    dataPayment.Add("req_address", "bojong gede #1 08/01");
                    #endregion

                    string JSONDataPayment = Helper.DictionaryToJson(dataPayment);
                    Debug.Write(JSONDataPayment);
                    Dictionary<string, object> dict_dataPayment = new Dictionary<string, object>();
                    dict_dataPayment.Add("data", JSONDataPayment);

                    string responsePayment = Doku_Api.doPayment(dict_dataPayment);
                    dynamic results = Newtonsoft.Json.JsonConvert.DeserializeObject(responsePayment);
                    if (results != null)
                    {
                        Literal1.Text = results;
                    }
                    else
                    {
                        Literal1.Text = "NO SERVER RESPONSE -- ";
                    }
                }
            }
        }
    }
}