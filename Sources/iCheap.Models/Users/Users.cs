using Newtonsoft.Json;

namespace iCheap.Models
{
    public partial class Users : BaseModel
    {
        [JsonProperty(PropertyName = "userID", NullValueHandling = NullValueHandling.Ignore)]
        public int? UserID { get; set; }

        [JsonProperty(PropertyName = "username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Ignore)]
        public UserRole Role { get; set; }
    }
}
