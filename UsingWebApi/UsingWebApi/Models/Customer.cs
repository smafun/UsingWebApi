using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsingWebApi.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }

        public String toString() { return this.Id + " " + this.Name + " " + this.Phone + " " + this.Email; }
    }
}
