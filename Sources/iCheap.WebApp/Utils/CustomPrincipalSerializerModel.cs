using iCheap.Models;

namespace iCheap.WebApp
{
    public class CustomPrincipalSerializerModel
    {
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public int UserId { get; set; }
    }
}