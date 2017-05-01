using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.Doku
{
    public class Doku_Initiate
    {
        //public const string prePaymentUrl = "http://luna2.nsiapay.com/api/payment/PrePayment";
        //public const string paymentUrl = "http://luna2.nsiapay.com/api/payment/paymentMip";

        public const string prePaymentUrl = "http://staging.doku.com/api/payment/PrePayment";
        public const string paymentUrl = "http://staging.doku.com/api/payment/paymentMip";
        public const string directPaymentUrl = "http://staging.doku.com/api/payment/PaymentMIPDirect";
        public const string generateCodeUrl = "http://staging.doku.com/api/payment/doGeneratePaymentCode";

        public static string sharedKey;
        public static string mallId;
    }
}