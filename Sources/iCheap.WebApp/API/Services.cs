using iCheap.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace iCheap.WebApp
{
    public class Services
    {
        private static HttpClient Client { get; set; }

        public static void Init()
        {
            Client = new HttpClient();
            Client.BaseAddress = new System.Uri(ConfigurationManager.AppSettings["ServiceURL"]);
        }

        public static T HttpGetObject<T>(
            string controller,
            string action)
        {
            if (Client != null)
            {
                var response = Client.GetAsync(GetRequestUrl(controller, action)).Result.Content.ReadAsStringAsync().Result;

                var tmp = JsonConvert.DeserializeObject<Response<T>>(response);

                return tmp.Status ? tmp.Data : default(T);
            }

            return default(T);
        }

        public static T HttpGetObject<T>(
            string controller,
            params object[] parameters)
        {
            if (Client != null)
            {
                var response = Client.GetAsync(GetRequestUrl(controller, parameters)).Result.Content.ReadAsStringAsync().Result;

                var tmp = JsonConvert.DeserializeObject<Response<T>>(response);

                return tmp.Status ? tmp.Data : default(T);
            }

            return default(T);
        }

        public static T HttpPostObject<T>(
            string controller,
            string action,
            T data)
        {
            if (Client != null)
            {
                var content = JsonConvert.SerializeObject(data);
                var response = Client.PostAsync(GetRequestUrl(controller, action), new StringContent(content, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;

                var tmp = JsonConvert.DeserializeObject<Response<T>>(response);

                return tmp.Data;
            }

            return default(T);
        }

        public static string GetRequestUrl(
            string controller,
            string action)
        {
            string result = $"/v1/{ controller }/{ action }";

            return result;
        }

        public static string GetRequestUrl(
            string controller, 
            params object[] parameters)
        {
            string action = string.Empty;
            foreach (var param in parameters)
                action += (param + "/");

            return GetRequestUrl(controller, action);
        }
    }
}
