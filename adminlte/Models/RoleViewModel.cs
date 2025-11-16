using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace adminlte.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [DisplayName("Role name")]
        public string Name { get; set; }
    }
}