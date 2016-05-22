using Newtonsoft.Json;

namespace iCheap.Models
{
    public class Cart
    {
        [JsonProperty(PropertyName = "key", NullValueHandling = NullValueHandling.Ignore)]
        public int Key { get; set; }

        [JsonProperty(PropertyName = "item", NullValueHandling = NullValueHandling.Ignore)]
        public Products Item { get; set; }

        [JsonProperty(PropertyName = "quantity", NullValueHandling = NullValueHandling.Ignore)]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "price", NullValueHandling = NullValueHandling.Ignore)]
        public int Price { get; set; }

        [JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public int Total { get; set; }
    }
}
