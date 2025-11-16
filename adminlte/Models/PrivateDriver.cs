using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace adminlte.Models
{
    public class PrivateDriver
    {
        public int Id { get; set; }
        public string PrivateDriverID { get; set; }
        [DisplayName("Driver Name")]
        public string DriverName { get; set; }
        [DisplayName("Driver Last Name")]
        public string DriverLastName { get; set; }
        [DisplayName("Driver National ID")]
        public string DriverNationalID { get; set; }
        [DisplayName("Driver Phone")]
        public string DriverPhone { get; set; }
        [DisplayName("Image")]
        public string DriverImage { get; set; }

        [DisplayName("Taxi Model")]
        public string TaxiModel { get; set; }
        [DisplayName("Taxi Plate")]
        public string TaxiPlate { get; set; }
        [DisplayName("Taxi Color")]
        public string TaxiColor { get; set; }
        [DisplayName("Taxi Image")]
        public string TaxiImage { get; set; }
        [DisplayName("Availability")]
        public bool Availability { get; set; }
    }
}