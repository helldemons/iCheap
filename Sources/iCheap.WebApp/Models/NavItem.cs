using Newtonsoft.Json;
using System.Web.Mvc;

namespace iCheap.WebApp
{
    public class NavItem
    {
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "controller", NullValueHandling = NullValueHandling.Ignore)]
        private string Controller { get; set; }

        [JsonProperty(PropertyName = "action", NullValueHandling = NullValueHandling.Ignore)]
        private string Action { get; set; }

        public string Url { get; set; }

        [JsonProperty(PropertyName = "icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "isDropdown", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDropDown { get; set; }

        public void CreateUrl(UrlHelper urlHelper)
        {
            Url = urlHelper.Action(Action, Controller);
        }
    }
}