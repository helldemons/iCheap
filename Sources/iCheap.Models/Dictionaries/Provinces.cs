using Newtonsoft.Json;

namespace iCheap.Models
{
    public class Provinces : BaseModel
    {
        [JsonProperty(PropertyName = "provinceId", NullValueHandling = NullValueHandling.Ignore)]
        public int? ProvinceID { get; set; }

        [JsonProperty(PropertyName = "provinceCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProvinceCode { get; set; }

        [JsonProperty(PropertyName = "vnName", NullValueHandling = NullValueHandling.Ignore)]
        public string VNName { get; set; }

        [JsonProperty(PropertyName = "enName", NullValueHandling = NullValueHandling.Ignore)]
        public string ENName { get; set; }

        [JsonProperty(PropertyName = "rank", NullValueHandling = NullValueHandling.Ignore)]
        public int? Rank { get; set; }

        [JsonProperty(PropertyName = "inActive", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InActive { get; set; }

        [JsonProperty(PropertyName = "note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; set; }
    }
}
