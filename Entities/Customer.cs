using System;
using System.Collections.Generic;

namespace SecuringWebApiJwt.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime TS { get; set; }
        public bool Active { get; set; }
        public bool Blocked { get; set; }
        public ICollection <Order> Orders { get; set; }
    }
}