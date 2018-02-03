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

        public Customer()
        {
        }

    /*    public Customer (long id, String name, String phone, String email)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
        }
    */
        public String toString() { return this.Id + " " + this.Name + " " + this.Phone + " " + this.Email; }
    }
}
