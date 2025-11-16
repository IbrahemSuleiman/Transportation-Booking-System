using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminlte.Models
{
    public class Ticket
    {
        public int id { get; set; }
        public int DriverID { get; set; }
        public int OrderID { get; set; }
        public bool State { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
    }
}