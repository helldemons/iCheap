using Newtonsoft.Json;

namespace iCheap.Models
{
    public partial class BlogCategories : BaseModel
    {
        [JsonProperty(PropertyName = "blogCategoryId", NullValueHandling = NullValueHandling.Ignore)]
        public int? BlogCategoryID { get; set; }

        [JsonProperty(PropertyName = "blogCategoryCode", NullValueHandling = NullValueHandling.Ignore)]
        public string BlogCategoryCode { get; set; }

        [JsonProperty(PropertyName = "vnName", NullValueHandling = NullValueHandling.Ignore)]
        public string VNName { get; set; }

        [JsonProperty(PropertyName = "enName", NullValueHandling = NullValueHandling.Ignore)]
        public string ENName { get; set; }

        [JsonProperty(PropertyName = "vnRewriteUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string VNRewriteUrl { get; set; }

        [JsonProperty(PropertyName = "enRewriteUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string ENRewriteUrl { get; set; }

        [JsonProperty(PropertyName = "vnNameSEO", NullValueHandling = NullValueHandling.Ignore)]
        public string VNNameSEO { get; set; }

        [JsonProperty(PropertyName = "enNameSEO", NullValueHandling = NullValueHandling.Ignore)]
        public string ENNameSEO { get; set; }

        [JsonProperty(PropertyName = "vnDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string VNDescription { get; set; }

        [JsonProperty(PropertyName = "enDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string ENDescription { get; set; }

        [JsonProperty(PropertyName = "parentID", NullValueHandling = NullValueHandling.Ignore)]
        public int? ParentID { get; set; }

        [JsonProperty(PropertyName = "level", NullValueHandling = NullValueHandling.Ignore)]
        public int? Level { get; set; }

        [JsonProperty(PropertyName = "inSystem", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InSystem { get; set; }

        [JsonProperty(PropertyName = "inDefault", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InDefault { get; set; }

        [JsonProperty(PropertyName = "rank", NullValueHandling = NullValueHandling.Ignore)]
        public int? Rank { get; set; }

        [JsonProperty(PropertyName = "tag", NullValueHandling = NullValueHandling.Ignore)]
        public string Tag { get; set; }

        [JsonProperty(PropertyName = "websiteDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string WebsiteDescription { get; set; }

        [JsonProperty(PropertyName = "thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        [JsonProperty(PropertyName = "note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; set; }

        [JsonProperty(PropertyName = "inActive", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InActive { get; set; }
    }
}
