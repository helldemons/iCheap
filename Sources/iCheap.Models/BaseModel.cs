using Newtonsoft.Json;
using System;

namespace iCheap.Models
{
    public class BaseModel
    {
        [JsonProperty(PropertyName = "inVisible", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InVisible { get; set; }

        [JsonProperty(PropertyName = "creater", NullValueHandling = NullValueHandling.Ignore)]
        public string Creater { get; set; }

        [JsonProperty(PropertyName = "createTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateTime { get; set; }

        [JsonProperty(PropertyName = "editer", NullValueHandling = NullValueHandling.Ignore)]
        public string Editer { get; set; }

        [JsonProperty(PropertyName = "editTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EditTime { get; set; }
    }
}
