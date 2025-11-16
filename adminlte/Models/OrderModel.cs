using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace adminlte.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int OrderModelID { get; set; }
        [DisplayName("Order Status")]
        public bool OrderStatus { get; set; }

        public string IDUser { get; set; }
        public int IDOrder { get; set; }
        public int IDPrivateDriver { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Order order { get; set; }
        public virtual PrivateDriver privatedriver { get; set; }
    }
}