using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastTestProject.Models
{
    public partial class Mailserver
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int Index { get; set; }
        public DateTime Date { get; set; }
    }
}