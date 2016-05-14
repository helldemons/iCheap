using Newtonsoft.Json;

namespace iCheap.Models
{
    public partial class Categories : BaseModel
    {
        [JsonProperty(PropertyName = "categoryId", NullValueHandling = NullValueHandling.Ignore)]
        public int? CategoryID { get; set; }

        [JsonProperty(PropertyName = "categoryCode", NullValueHandling = NullValueHandling.Ignore)]
        public string CategoryCode { get; set; }

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

        [JsonProperty(PropertyName = "parentId", NullValueHandling = NullValueHandling.Ignore)]
        public int? ParentID { get; set; }

        [JsonProperty(PropertyName = "level", NullValueHandling = NullValueHandling.Ignore)]
        public int? Level { get; set; }

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

        [JsonProperty(PropertyName = "parent", NullValueHandling = NullValueHandling.Ignore)]
        public Categories Parent { get; set; }
    }
}
