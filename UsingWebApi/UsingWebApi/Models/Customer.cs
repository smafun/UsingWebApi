﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsingWebApi.Models
{
    public class Customer
    {
        public long Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Phone { get; set; }
        [Required]
        public String Email { get; set; }

        public String toString() { return this.Id + " " + this.Name + " " + this.Phone + " " + this.Email; }

        internal static object SingleOrDefaultAsync(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
