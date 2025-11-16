using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace adminlte.Models
{
    public class Bus
    {
        public int Id { get; set; }
        public string BusID { get; set; }
        [DisplayName("Bus Model")]
        public string BusModel { get; set; }
        [DisplayName("Bus Plate")]
        public string BusPlate { get; set; }
        [DisplayName("Bus Color")]
        public string BusColor { get; set; }
        [DisplayName("Bus Number")]
        public string BusNumber { get; set; }

        public int IDVehicle { get; set; }
        public virtual Vehicle vehicle { get; set; }
    }
}