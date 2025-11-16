using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace adminlte.Models
{
    public class Travel
    {
        public int Id { get; set; }
        public string TravelID { get; set; }
        [DisplayName("Location")]
        public string Location { get; set; }
        [DisplayName("Destination")]
        public string Destination { get; set; }
        [DisplayName("Leave time")]
        public string Leavetime { get; set; }        
        [DisplayName("Notes")]
        public string Notes { get; set; }

        public int IDCompany { get; set; }
        public int PassengerNumber { get; set; }
        public int IDVehicle { get; set; }

        public virtual Company company { get; set; }
        public virtual ICollection<Passenger> Passengerlist { get; set; }
        public virtual Vehicle vehicle { get; set; }
       

    }
}