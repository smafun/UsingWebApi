using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsingWebApi.Models
{
    public class Order
    {
        public long id { get; set; }
        [Display (Name="Customer Id")]
        public long CustomerId { get; set; }
        [Display(Name = "Adress From")]
        public String addressFrom { get; set; }
        [Display(Name = "Adress To")]
        public String addressTo { get; set; }
        public String serviceTypes { get; set; }
        [Display(Name = "Text Field")]
        public String txtField { get; set; }
        public String date { get; set; }


        public String toString() { return this.CustomerId + " " + this.addressFrom + " " + this.addressTo + " " + this.serviceTypes + " " + this.txtField + " " + this.date; }
    }
}
