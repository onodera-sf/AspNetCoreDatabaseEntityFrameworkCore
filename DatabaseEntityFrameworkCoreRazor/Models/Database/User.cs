using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseEntityFrameworkCoreRazor.Models.Database
{
    public partial class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
