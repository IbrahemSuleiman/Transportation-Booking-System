using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace adminlte.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyID { get; set; }
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        [DisplayName("Company Location")]
        public string CompanyLocation { get; set; }
        [DisplayName("Company Fax")]
        public string CompanyFax { get; set; }
        [DisplayName("Company Tele-Phone")]
        public string CompanyTelePhone { get; set; }
        [DisplayName("About Company")]
        public string AboutCompany { get; set; }

        public virtual ICollection<Vehicle> Fleet { get; set; }
        public virtual ICollection<Travel> Travel_list { get; set; }
    }
}