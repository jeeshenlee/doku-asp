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
    public partial class merchant_mandiri_example : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Doku_Initiate.sharedKey = "k8UhY5t4RF4e"; //local
                //Doku_Initiate.sharedKey = "aKh4dSX72d6C";//luna
                Doku_Initiate.mallId = "2074";

                dynamic postData = Newtonsoft.Json.JsonConvert.DeserializeObject(Request.Form["data"]);
                if (postData != null)
                {
                    #region PREDATA
                    string invoice_no = "invoice_" + Helper.getTime();
                    string amount = "10000.00";
                    string device_id = postData.req_device_id.Value;

                    string payment_channel = postData.req_payment_channel.Value;

                    string challenge_1 = postData.req_challenge_code_1;
                    string challenge_2 = postData.req_challenge_code_2;
                    string challenge_3 = postData.req_challenge_code_3;
                    string card_number = postData.req_card_number;
                    string response_token = postData.req_response_token;

                    Dictionary<string, string> param = new Dictionary<string, string>();
                    param.Add("amount", amount);
                    param.Add("invoice", invoice_no);
                    param.Add("currency", "360");
                    param.Add("device_id", device_id);
                    string words = Library.doCreateWords(param);

                    Dictionary<string, string> customer = new Dictionary<string, string>();
                    customer.Add("name", "TEST NAME");
                    customer.Add("data_phone", "08121111111");
                    customer.Add("data_email", "test@test.com");
                    customer.Add("data_address", "bojong gede #1 08/01");
                    string JSONCustomer = Helper.DictionaryToJson(customer);

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
                    dataPayment.Add("req_words_raw", Library.doCreateWordsRaw(param));
                    dataPayment.Add("req_purchase_amount", amount);
                    dataPayment.Add("req_trans_id_merchant", invoice_no);
                    dataPayment.Add("req_request_date_time", Helper.getDate());
                    dataPayment.Add("req_currency", "360");
                    dataPayment.Add("req_purchase_currency", "360");
                    dataPayment.Add("req_session_id", Helper.GetSHA1HashData(Helper.getDate()));
                    dataPayment.Add("req_name", customer["name"]);
                    dataPayment.Add("req_payment_channel", payment_channel);
                    dataPayment.Add("req_basket", JSONBasket);
                    dataPayment.Add("req_email", customer["data_email"]);
                    dataPayment.Add("req_card_number", card_number);
                    dataPayment.Add("req_challenge_code_1", challenge_1);
                    dataPayment.Add("req_challenge_code_2", challenge_2);
                    dataPayment.Add("req_challenge_code_3", challenge_3);
                    dataPayment.Add("req_mobile_phone", customer["data_phone"]);
                    dataPayment.Add("req_address", customer["data_address"]);
                    dataPayment.Add("req_device_id", device_id);
                    #endregion

                    string JSONDataPayment = Helper.DictionaryToJson(dataPayment);
                    Debug.Write(JSONDataPayment);
                    Dictionary<string, object> dict_dataPayment = new Dictionary<string, object>();
                    dict_dataPayment.Add("data", JSONDataPayment);

                    string responsePayment = Doku_Api.doDirectPayment(dict_dataPayment);
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