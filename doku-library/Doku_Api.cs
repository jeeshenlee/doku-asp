using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Doku;
using System.Diagnostics;

namespace Com.Doku
{
    public class Doku_Api
    {
        public static string doPrePayment(Dictionary<string, object> paramData)
        {
            return Helper.Curl(Doku_Initiate.prePaymentUrl, paramData);
        }

        public static string doPayment(Dictionary<string, object> paramData)
        {
            return Helper.Curl(Doku_Initiate.paymentUrl, paramData); 
        }

        public static string doDirectPayment(Dictionary<string, object> paramData)
        {
            return Helper.Curl(Doku_Initiate.directPaymentUrl, paramData);
        }

        public static string doGeneratePaycode(Dictionary<string, object> paramData)
        {
            return Helper.Curl(Doku_Initiate.generateCodeUrl, paramData);
        }
    }
}