using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace iCheap.WebApp
{
    public class BaseHelpers
    {
        public static List<NavItem> GetNavItemList(UrlHelper urlHelper, string jsonPath)
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
    }
}