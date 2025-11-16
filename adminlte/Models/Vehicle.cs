using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace adminlte.Models
{
    public class Vehicle
    {
        public int Id { get; set; } 
        public string VehicleID { get; set; }

        public int IDCompany { get; set; }
        public int IDBus { get; set; }
        public int IDPublicDriver { get; set; }
        public int IDTravel { get; set; }

    }
}