using Newtonsoft.Json;

namespace iCheap.Models
{
    class CategoryProducts
    {
        [JsonProperty(PropertyName = "categoryID", NullValueHandling = NullValueHandling.Ignore)]
        public int? CategoryID { get; set; }

        [JsonProperty(PropertyName = "productID", NullValueHandling = NullValueHandling.Ignore)]
        public int? ProductID { get; set; }
    }
}
