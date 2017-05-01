using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.Doku
{
    public class Doku_Initiate
    {
        // Testing Payment Urls
        //public const string prePaymentUrl = "http://staging.doku.com/api/payment/PrePayment";
        //public const string paymentUrl = "http://staging.doku.com/api/payment/paymentMip";
        //public const string directPaymentUrl = "http://staging.doku.com/api/payment/PaymentMIPDirect";
        //public const string generateCodeUrl = "http://staging.doku.com/api/payment/doGeneratePaymentCode";

        // Production Payment Urls
        public const string prePaymentUrl = "https://pay.doku.com/api/payment/PrePayment";
        public const string paymentUrl = "https://pay.doku.com/api/payment/paymentMip";
        public const string directPaymentUrl = "https://pay.doku.com/api/payment/PaymentMIPDirect";
        public const string generateCodeUrl = "https://pay.doku.com/api/payment/doGeneratePaymentCode";

        public static string sharedKey;
        public static string mallId;
    }
}