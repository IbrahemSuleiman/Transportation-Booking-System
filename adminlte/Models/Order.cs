using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace adminlte.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        [DisplayName("Location")]
        public string Location { get; set; }
        [DisplayName("Distination")]
        public string Distination { get; set; }
        [DisplayName("Time")]
        public string Time { get; set; }
        [DisplayName("Sit number")]
        public int SitNumber { get; set; }
        [DisplayName("Note")]
        public string Note { get; set; }
        public int IDTicket { get; set; }
        public string IDUser { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}