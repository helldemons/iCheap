using iCheap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace iCheap.WebApp
{
    public class CustomPrincipal : IPrincipal
    {
        public string Username { get; set; }
        public int UserId { get; set; }
        public UserRole Role { get; set; }

        public IIdentity Identity
        {
            get { return new GenericIdentity(Username); }
        }
        public CustomPrincipal(string username)
        {
            Username = username;
        }

        public bool IsInRole(string role)
        {
            return string.Equals(role, Role.ToString(), StringComparison.OrdinalIgnoreCase);
        }
    }
}