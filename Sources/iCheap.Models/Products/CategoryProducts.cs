using Newtonsoft.Json;

namespace iCheap.Models
{
    class CategoryProducts
    {
        [JsonProperty(PropertyName = "categoryId", NullValueHandling = NullValueHandling.Ignore)]
        public int? CategoryID { get; set; }

        [JsonProperty(PropertyName = "productId", NullValueHandling = NullValueHandling.Ignore)]
        public int? ProductID { get; set; }
    }
}
