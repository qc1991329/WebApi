using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class VehTotal
    {
        private string privince;
        private int total;

        public VehTotal(string privince, int total)
        {
            this.Privince = privince;
            this.Total = total;
        }

        public String Privince { get; set; }
        public int Total { get; set; } 
    }
}