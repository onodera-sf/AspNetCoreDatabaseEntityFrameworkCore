using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseEntityFrameworkCoreMvc.Models.Database
{
    [Table("User")]
    public partial class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        public int? Age { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
