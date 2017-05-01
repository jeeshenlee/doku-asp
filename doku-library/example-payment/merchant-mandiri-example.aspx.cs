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
    public partial class merchant_mandiri_example : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string words = "";
            if (!Page.IsPostBack)
            {
                Doku_Initiate.sharedKey = "M8Y79iqFvwN4"; //staging
                //Doku_Initiate.sharedKey = "k8UhY5t4RF4e"; //local
                //Doku_Initiate.sharedKey = "aKh4dSX72d6C";//luna
                //Doku_Initiate.mallId = "2074";
                Doku_Initiate.mallId = "4401";

                #region PREDATA
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("amount", "100000.00");
                param.Add("invoice", Request.Form["invoice_no"]);
                param.Add("currency", "360");
                
                string cc = null;
                if (Request.Form["cc_number"] != null) 
                    cc = Request.Form["cc_number"].ToString().Replace(" - ", "");

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

                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("req_mall_id", "4401");
                data.Add("req_chain_merchant", "NA");
                data.Add("req_amount", param["amount"]);
                data.Add("req_words", words);
                data.Add("req_purchase_amount", param["amount"]);
                data.Add("req_trans_id_merchant", Request.Form["invoice_no"]);
                data.Add("req_request_date_time", Helper.getDate());
                data.Add("req_currency", "360");
                data.Add("req_purchase_currency" , "360");
                data.Add("req_session_id", Helper.GetSHA1HashData(Helper.getDate()));
                data.Add("req_name", customer["name"]);
                data.Add("req_payment_channel", "02");
                data.Add("req_email", customer["data_email"]);
                data.Add("req_card_number", cc);
                data.Add("req_basket", Helper.ListToJson(basket));
                data.Add("req_challenge_code_1", Request.Form["CHALLENGE_CODE_1"]);
                data.Add("req_challenge_code_2", Request.Form["CHALLENGE_CODE_2"]);
                data.Add("req_challenge_code_3", Request.Form["CHALLENGE_CODE_3"]);
                data.Add("req_response_token", Request.Form["response_token"]);
                data.Add("req_mobile_phone", customer["data_phone"]);
                data.Add("req_address", customer["data_address"]);    
                #endregion

                string JSONData = Helper.DictionaryToJson(data);
                Debug.Write(JSONData);

                Dictionary<string, object> datas = new Dictionary<string, object>();
                datas.Add("data", JSONData);

                string responsePayment = Doku_Api.doDirectPayment(datas);

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