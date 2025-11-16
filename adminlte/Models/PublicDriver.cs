using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace adminlte.Models
{
    public class PublicDriver
    {
        public int Id { get; set; }
        public string PublicDriverID { get; set; }
        [DisplayName("Driver Name")]
        public string DriverName { get; set; }
        [DisplayName("Driver Last Name")]
        public string DriverLastName { get; set; }

        [DisplayName("Driver National ID")]
        public string DriverNationalID { get; set; }
        [DisplayName("Driver Phone")]
        public string DriverPhone { get; set; }
        [DisplayName("Driver Image")]
        public string DriverImage { get; set; }

        public int IDVehicle { get; set; }
        public virtual Vehicle vehicle { get; set; }
    }
}