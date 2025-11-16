using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace adminlte.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        [DisplayName("Sit Number")]
        public string SitNumber { get; set; }
        public string PassengerID { get; set; }

        public string IDUser { get; set; }
        public int IDTravel { get; set; }
        public int IDCompany { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}