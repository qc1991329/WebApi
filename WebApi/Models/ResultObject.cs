using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ResultObject 
    {
        public String state { get; set; }

        public String msg { get; set; }


        public object Data { get; set; } 

    }
}