using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminlte.Models
{
    public class MailBox
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string TimeStamp { get; set; }
        public string Sender { get; set; }
        public string SenderID { get; set; }
        public string TargetID { get; set; }
    }
}