using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsingWebApi.Models
{
    public class Order
    {
        public long Id { get; set; }
        [Display(Name = "Adress From")]
        public String AddressFrom { get; set; }
        [Display(Name = "Adress To")]
        public String AddressTo { get; set; }
        [Display(Name = "Service Types")]
        public String ServiceTypes { get; set; }
        [Display(Name = "Text Field")]
        public String TxtField { get; set; }
        [Display(Name = "Date")]
        public String Date { get; set; }
        [Display(Name = "Customer Id")]
        public long CustomerId { get; set; }

        public String toString() { return this.CustomerId + " " + this.AddressFrom + " " + this.AddressTo + " " + this.ServiceTypes + " " + this.TxtField + " " + this.Date; }
    }
}
