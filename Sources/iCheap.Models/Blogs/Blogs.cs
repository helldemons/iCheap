using Newtonsoft.Json;

namespace iCheap.Models
{
    public partial class Blogs : BaseModel
    {
        [JsonProperty(PropertyName = "blogID", NullValueHandling = NullValueHandling.Ignore)]
        public int? BlogID { get; set; }

        [JsonProperty(PropertyName = "blogCode", NullValueHandling = NullValueHandling.Ignore)]
        public string BlogCode { get; set; }

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

        [JsonProperty(PropertyName = "blogCategoryID", NullValueHandling = NullValueHandling.Ignore)]
        public int? BlogCategoryID { get; set; }

        [JsonProperty(PropertyName = "viewCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? ViewCount { get; set; }

        [JsonProperty(PropertyName = "voteCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? VoteCount { get; set; }

        [JsonProperty(PropertyName = "voteRatio", NullValueHandling = NullValueHandling.Ignore)]
        public float? VoteRatio { get; set; }

        [JsonProperty(PropertyName = "likeCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? LikeCount { get; set; }

        [JsonProperty(PropertyName = "vnContent", NullValueHandling = NullValueHandling.Ignore)]
        public string VNContent { get; set; }

        [JsonProperty(PropertyName = "enContent", NullValueHandling = NullValueHandling.Ignore)]
        public string ENContent { get; set; }

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

        [JsonProperty(PropertyName = "blogCategory", NullValueHandling = NullValueHandling.Ignore)]
        public BlogCategories BlogCategory { get; set; }
    }
}
