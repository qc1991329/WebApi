using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class WorkingTime
    {

        /*
        public String province { get; set; }

        public int month { get; set; }

        public double total { get; set; }
        */

        private String province;
        private int month;
        private double total;

        public WorkingTime(string province, int month, double total)
        {
            this.province = province;
            this.month = month;
            this.total = total;
        }

        public string Province
        {
            get
            {
                return province;
            }

            set
            {
                province = value;
            }
        }

        public int Month
        {
            get
            {
                return month;
            }

            set
            {
                month = value;
            }
        }

        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }
    }
}