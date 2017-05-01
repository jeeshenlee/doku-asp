using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Com.Doku
{
    public class Helper
    {
        /// <summary>
        /// to get time in integer format
        /// </summary>
        /// <returns>return integer date time now</returns>
        public static int getTime()
        {
            int result = 0;
            try
            {
                result = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds; 
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
            }
            return result;
        }

        /// <summary>
        /// to get date formatted yyyy mm dd hh mm ss
        /// </summary>
        /// <returns>return string formatted date</returns>
        public static string getDate()
        {
            DateTime date = DateTime.Now;
            return date.ToString("yyyyMMddHmmss");
        }

        /// <summary>
        /// take any string and encrypt it using SHA1 then
        /// return the encrypted data
        /// </summary>
        /// <param name="data">input text you will enterd to encrypt it</param>
        /// <returns>return the encrypted text as hexadecimal string</returns>
        public static string GetSHA1HashData(string data)
        {
            string dataString = data;
            SHA1 hash = SHA1CryptoServiceProvider.Create();
            byte[] plainTextBytes = Encoding.ASCII.GetBytes(dataString);
            byte[] hashBytes = hash.ComputeHash(plainTextBytes);
            string localChecksum = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            return localChecksum;
        }

        /// <summary>
        /// function CURL http request to another url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns>return string</returns>
        public static string Curl(string url, Dictionary<string, object> paramDict)
        {
            string result = "";
            try
            {
                HttpWebRequest req = WebRequest.Create(new Uri(url)) as HttpWebRequest;
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                StringBuilder paramz = new StringBuilder();
                List<string> paramKey = new List<string>();
                foreach (var item in paramDict.Keys)
                {
                    paramKey.Add(item);
                }
                for (int i = 0; i < paramDict.Count; i++)
                {
                    paramz.Append(paramKey[i]);
                    paramz.Append("=");
                    paramz.Append(paramDict[paramKey[i]]);
                    paramz.Append("&");
                }
                // Encode the parameters as form data:
                byte[] formData =
                    UTF8Encoding.UTF8.GetBytes(paramz.ToString());
                req.ContentLength = formData.Length;
                //Send request
                using (Stream post = req.GetRequestStream())
                {
                    post.Write(formData, 0, formData.Length);
                }
                using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(resp.GetResponseStream());
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
            }
            return result;
        }

        public static string DictionaryToJson(Dictionary<string, object> dict)
        {
            return JsonConvert.SerializeObject(dict);
        }

        public static string DictionaryToJson(Dictionary<string, string> dict)
        {
            return JsonConvert.SerializeObject(dict);
        }

        public static string ListToJson(List<string> list)
        {
            return JsonConvert.SerializeObject(list);
        }
    }
}