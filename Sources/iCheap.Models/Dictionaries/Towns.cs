using Newtonsoft.Json;

namespace iCheap.Models
{
    public class Towns : BaseModel
    {
        [JsonProperty(PropertyName = "townId", NullValueHandling = NullValueHandling.Ignore)]
        public int? TownID { get; set; }

        [JsonProperty(PropertyName = "townCode", NullValueHandling = NullValueHandling.Ignore)]
        public string TownCode { get; set; }

        [JsonProperty(PropertyName = "provinceId", NullValueHandling = NullValueHandling.Ignore)]
        public int? ProvinceID { get; set; }

        [JsonProperty(PropertyName = "districtId", NullValueHandling = NullValueHandling.Ignore)]
        public int? DistrictID { get; set; }

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

        [JsonProperty(PropertyName = "district", NullValueHandling = NullValueHandling.Ignore)]
        public Districts District { get; set; }
    }
}
