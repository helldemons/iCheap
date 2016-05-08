using Newtonsoft.Json;
using System;
using System.Net;

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

    public class Response<T>
    {
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public bool Status { get; set; }

        [JsonProperty(PropertyName = "statusCode", NullValueHandling = NullValueHandling.Ignore)]
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrMess { get; set; }

        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }
    }

    public enum UserRole
    {
        Admin = 0,
        User = 1
    }
}
