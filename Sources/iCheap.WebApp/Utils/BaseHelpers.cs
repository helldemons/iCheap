using iCheap.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCheap.WebApp
{
    public class BaseHelpers
    {
        public static List<NavItem> GetNavItemList(
            UrlHelper urlHelper,
            string jsonPath)
        {
            List<NavItem> result = new List<NavItem>();
            if (File.Exists(jsonPath))
            {
                using (StreamReader file = File.OpenText(jsonPath))
                {
                    result = JsonConvert.DeserializeObject<IEnumerable<NavItem>>(file.ReadToEndAsync().Result).ToList();
                }
                foreach (var nav in result)
                    nav.CreateUrl(urlHelper);
            }
            return result;
        }

        public static Response<T> CreateResponse<T>(
            T data,
            string message = null)
        {
            var status = string.IsNullOrEmpty(message);

            var result = new Response<T>
            {
                Status = status,
                StatusCode = System.Net.HttpStatusCode.OK,
                ErrMess = string.IsNullOrEmpty(message) ? null : message,
            };
            if (data != null && !data.Equals(DBNull.Value))
                result.Data = data;

            return result;
        }

        public static string GetRequestDomain(HttpRequestBase Request)
        {
            return string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Host, (Request.Url.IsDefaultPort) ? "" : string.Format(":{0}", Request.Url.Port));
        }

        public static IEnumerable<Categories> GetParentChildCategoryList(IEnumerable<Categories> categories)
        {
            var childs = categories.Where(p => p.ParentID != 0)
                .GroupBy(c => c.ParentID,
                        (key, elements) => new
                        {
                            Id = key,
                            Items = elements
                        }).ToList();
            var result = categories.Where(p => p.ParentID == 0).ToList();
            result.ForEach(c =>
            {
                var _childs = childs.Where(r => r.Id == c.CategoryID).FirstOrDefault();
                if (_childs != null)
                    c.Childs = _childs.Items;
            });

            return result;
        }

        public static string ConvertPriceToString(decimal price)
        {
            return string.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:C0}", price).Trim();
        }

        public static string GetRateHtml(int count)
        {
            var result = @"<span class=""rating"">";
            for (int i = 1; i <= 5; i++)
            {
                if (i <= count) result += @"<i class=""icon-star-3""></i>";
                else result += @"<i class=""icon-star-empty""></i>";
            }
            result += "</span>";
            return result;
        }
    }

    public class ResultItem
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}