using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace adminlte.Models
{
    public class Client
    {
        public int? Id { get; set; }
        [DisplayName("User name")]
        public string UserName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("User Role")]
        public string UserRole { get; set; }
        [DisplayName("Date of birth")]
        public DateTime DOB { get; set; }
        [DisplayName("Registration date")]
        public DateTime RegistrationDate { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        [DisplayName("Mobile")]
        public string Mobile { get; set; }
        [DisplayName("National Id")]
        public string NationalId { get; set; }
        [DisplayName("Image")]
        public string ImagePath { get; set; }

        [Required]
        public string IDUser { get; set; }
        //public virtual ApplicationUser User { get; set; }
    }
}