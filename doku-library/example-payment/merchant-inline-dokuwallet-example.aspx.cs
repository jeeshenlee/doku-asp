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
    public partial class merchant_inline_dokuwallet_example : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string words = "";
            if (!Page.IsPostBack)
            {
                Doku_Initiate.sharedKey = "M8Y79iqFvwN4"; //staging
                //Doku_Initiate.sharedKey = "k8UhY5t4RF4e"; //local
                //Doku_Initiate.sharedKey = "aKh4dSX72d6C";//luna
                Doku_Initiate.mallId = Request.Form["doku-mall-id"];

                #region PREDATA
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("amount", Request.Form["doku-amount"]);
                param.Add("invoice", Request.Form["doku-invoice-no"]);
                param.Add("currency", Request.Form["doku-currency"]);
                param.Add("pairing_code", Request.Form["doku-pairing-code"]);
                param.Add("token", Request.Form["doku-token"]);
                words = Library.doCreateWords(param);

                List<string> basket = new List<string>();
                basket.Add("sayur");
                basket.Add("10000.00");
                basket.Add("1");
                basket.Add("10000.00");
                basket.Add(";");
                basket.Add("buah");
                basket.Add("10000.00");
                basket.Add("1");
                basket.Add("10000.00");
                basket.Add(";");
                string JSONBasket = Library.formatBasket(Helper.ListToJson(basket));

                Dictionary<string, string> customer = new Dictionary<string, string>();
                customer.Add("name", "TEST NAME");
                customer.Add("data_phone", "08121111111");
                customer.Add("data_email", "test@test.com");
                customer.Add("data_address", "bojong gede #1 08/01");
                string JSONCustomer = Helper.DictionaryToJson(customer);

                Dictionary<string, object> dataPrePayment = new Dictionary<string, object>();
                dataPrePayment.Add("req_mall_id", Request.Form["doku-mall-id"]);
                dataPrePayment.Add("req_chain_merchant", Request.Form["doku-chain-merchant"]);
                dataPrePayment.Add("req_amount", Request.Form["doku-amount"]);
                dataPrePayment.Add("req_words", words);
                dataPrePayment.Add("req_purchase_amount", Request.Form["doku-amount"]);
                dataPrePayment.Add("req_trans_id_merchant", Request.Form["doku-invoice-no"]);
                dataPrePayment.Add("req_request_date_time", Helper.getDate());
                dataPrePayment.Add("req_currency", Request.Form["doku-currency"]);
                dataPrePayment.Add("req_purchase_currency", Request.Form["doku-currency"]);
                dataPrePayment.Add("req_session_id", Helper.GetSHA1HashData(Helper.getDate()));
                dataPrePayment.Add("req_name", customer["name"]);
                dataPrePayment.Add("req_payment_channel", "04");
                dataPrePayment.Add("req_basket", JSONBasket);
                dataPrePayment.Add("req_email", customer["data_email"]);
                dataPrePayment.Add("req_token_id", Request.Form["doku-token"]);
                dataPrePayment.Add("req_mobile_phone", customer["data_phone"]);
                dataPrePayment.Add("req_address", customer["data_address"]);

                #endregion

                string JSONDataPayment = Helper.DictionaryToJson(dataPrePayment);
                Debug.Write(JSONDataPayment);
                Dictionary<string, object> dict_dataPayment = new Dictionary<string, object>();
                dict_dataPayment.Add("data", JSONDataPayment);

                string responsePayment = Doku_Api.doPayment(dict_dataPayment);
                dynamic results = Newtonsoft.Json.JsonConvert.DeserializeObject(responsePayment);

                if (results != null)
                {
                    var code = results.res_response_code;
                    if (code != null && code.Value == "0000")
                    {
                        Literal1.Text = "PAYMENT SUCCESS -- ";
                    }
                    else
                    {
                        Literal1.Text = "PAYMENT FAILED -- ";
                    }
                }
                else
                {
                    Literal1.Text = "NO SERVER RESPONSE -- ";
                }

                Literal1.Text = results;
            }
        }
    }
}