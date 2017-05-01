using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using Com.Doku;
using System.Diagnostics;

namespace Com.Doku
{
    public class Library
    {
        public static string doCreateWords(Dictionary<string, string> param)
        {
            string result = "";
            try
            {
                if (param.ContainsKey("device_id") && !param["device_id"].Equals(""))
                {
                    if (param.ContainsKey("pairing_code") && !param.ContainsKey("pairing_code").Equals(""))
                    {
                        return Helper.GetSHA1HashData(param["amount"] + Doku_Initiate.mallId + Doku_Initiate.sharedKey + param["invoice"] + param["currency"] + param["token"] + param["pairing_code"] + param["device_id"]);
                    }
                    else
                    {
                        return Helper.GetSHA1HashData(param["amout"] + Doku_Initiate.mallId + Doku_Initiate.sharedKey + param["invoice"] + param["currency"] + param["device_id"]);
                    }
                }
                else if (param.ContainsKey("pairing_code") && !param["pairing_code"].Equals(""))
                {
                    return Helper.GetSHA1HashData(param["amount"] + Doku_Initiate.mallId + Doku_Initiate.sharedKey + param["invoice"] + param["currency"] + param["token"] + param["pairing_code"]);
                }
                else if (param.ContainsKey("currency") && !param["currency"].Equals(""))
                {
                    return Helper.GetSHA1HashData(param["amount"] + Doku_Initiate.mallId + Doku_Initiate.sharedKey + param["invoice"] + param["currency"]);
                }
                else 
                {
                    return Helper.GetSHA1HashData(param["amount"] + Doku_Initiate.mallId + Doku_Initiate.sharedKey + param["invoice"]);
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
            }
            return result;
        }

        public static string doCreateWordsRaw(Dictionary<string, string> param)
        {
            string result = "";
            try
            {
                if (param.ContainsKey("device_id") && !param["device_id"].Equals(""))
                {
                    if (param.ContainsKey("pairing_code") && !param["pairing_code"].Equals(""))
                    {
                        return Helper.GetSHA1HashData(param["amount"] + Doku_Initiate.mallId + Doku_Initiate.sharedKey + param["invoice"] + param["currency"] + param["token"] + param["pairing_code"] + param["device_id"]);
                    } 
                    else 
                    {
                        return Helper.GetSHA1HashData(param["amount"] + Doku_Initiate.mallId + Doku_Initiate.sharedKey + param["invoice"] + param["currency"] + param["device_id"]);
                    }
                }
                else if (param.ContainsKey("pairing_code") && !param["pairing_code"].Equals(""))
                {
                    return param["amount"] + Doku_Initiate.mallId + Doku_Initiate.sharedKey + param["invoice"] + param["currency"] + param["token"] + param["pairing_code"];
                }
                else if (param.ContainsKey("currency") && !param["currency"].Equals(""))
                {
                    return param["amount"] + Doku_Initiate.mallId + Doku_Initiate.sharedKey + param["invoice"] + param["currency"];
                }
                else
                {
                    return param["amount"] + Doku_Initiate.mallId + Doku_Initiate.sharedKey + param["invoice"];
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
            }
            return result;
        }

        public static string formatBasket(string paramString)
        {
            string result = null;
            try
            {
                //clear characters [ " \ ]
                result = paramString.Replace("[", "");
                result = result.Replace("\"", "");
                result = result.Replace("\\", "");
                result = result.Replace("]", "");
                result = result.Replace(",;,", ";");
                result = result.Replace(",;", ";");
                return result;
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
            }
            return result;
        }
    }
}