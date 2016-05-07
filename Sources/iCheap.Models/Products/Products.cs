using Newtonsoft.Json;

namespace iCheap.Models
{
    public partial class Products : BaseModel
    {
        [JsonProperty(PropertyName = "productID", NullValueHandling = NullValueHandling.Ignore)]
        public int? ProductID { get; set; }

        [JsonProperty(PropertyName = "productCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductCode { get; set; }

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

        [JsonProperty(PropertyName = "vnFullInformation", NullValueHandling = NullValueHandling.Ignore)]
        public string VNFullInformation { get; set; }

        [JsonProperty(PropertyName = "enFullInformation", NullValueHandling = NullValueHandling.Ignore)]
        public string ENFullInformation { get; set; }

        [JsonProperty(PropertyName = "available", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Available { get; set; }

        [JsonProperty(PropertyName = "soldQuantity", NullValueHandling = NullValueHandling.Ignore)]
        public int? SoldQuantity { get; set; }

        [JsonProperty(PropertyName = "viewCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? ViewCount { get; set; }

        [JsonProperty(PropertyName = "voteCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? VoteCount { get; set; }

        [JsonProperty(PropertyName = "voteRatio", NullValueHandling = NullValueHandling.Ignore)]
        public float? VoteRatio { get; set; }

        [JsonProperty(PropertyName = "likeCount", NullValueHandling = NullValueHandling.Ignore)]
        public int? LikeCount { get; set; }

        [JsonProperty(PropertyName = "inNew", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InNew { get; set; }

        [JsonProperty(PropertyName = "inHot", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InHot { get; set; }

        [JsonProperty(PropertyName = "inBestSale", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InBestSale { get; set; }

        [JsonProperty(PropertyName = "inSaleOff", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InSaleOff { get; set; }

        [JsonProperty(PropertyName = "price", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Price { get; set; }

        [JsonProperty(PropertyName = "originalPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? OriginalPrice { get; set; }

        [JsonProperty(PropertyName = "marketPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? MarketPrice { get; set; }

        [JsonProperty(PropertyName = "interestRate", NullValueHandling = NullValueHandling.Ignore)]
        public float? InterestRate { get; set; }

        [JsonProperty(PropertyName = "differenceRate", NullValueHandling = NullValueHandling.Ignore)]
        public float? DifferenceRate { get; set; }

        [JsonProperty(PropertyName = "inWarranty", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InWarranty { get; set; }

        [JsonProperty(PropertyName = "warranty", NullValueHandling = NullValueHandling.Ignore)]
        public int? Warranty { get; set; }

        [JsonProperty(PropertyName = "warrantyType", NullValueHandling = NullValueHandling.Ignore)]
        public int? WarrantyType { get; set; }

        [JsonProperty(PropertyName = "originID", NullValueHandling = NullValueHandling.Ignore)]
        public int? OriginID { get; set; }

        [JsonProperty(PropertyName = "brandID", NullValueHandling = NullValueHandling.Ignore)]
        public int? BrandID { get; set; }

        [JsonProperty(PropertyName = "discountQuantity", NullValueHandling = NullValueHandling.Ignore)]
        public int? DiscountQuantity { get; set; }

        [JsonProperty(PropertyName = "discountRate", NullValueHandling = NullValueHandling.Ignore)]
        public float? DiscountRate { get; set; }

        [JsonProperty(PropertyName = "discountAmount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? DiscountAmount { get; set; }

        [JsonProperty(PropertyName = "rank", NullValueHandling = NullValueHandling.Ignore)]
        public int? Rank { get; set; }

        [JsonProperty(PropertyName = "tag", NullValueHandling = NullValueHandling.Ignore)]
        public string Tag { get; set; }

        [JsonProperty(PropertyName = "websiteDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string WebsiteDescription { get; set; }

        [JsonProperty(PropertyName = "thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        [JsonProperty(PropertyName = "images", NullValueHandling = NullValueHandling.Ignore)]
        public string Images { get; set; }

        [JsonProperty(PropertyName = "videos", NullValueHandling = NullValueHandling.Ignore)]
        public string Videos { get; set; }

        [JsonProperty(PropertyName = "note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; set; }

        [JsonProperty(PropertyName = "inActive", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InActive { get; set; }

        [JsonProperty(PropertyName = "origin", NullValueHandling = NullValueHandling.Ignore)]
        public Origins Origin { get; set; }

        [JsonProperty(PropertyName = "brand", NullValueHandling = NullValueHandling.Ignore)]
        public Brands Brand { get; set; }
    }
}
