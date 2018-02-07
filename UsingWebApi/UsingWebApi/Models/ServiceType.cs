using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UsingWebApi.Models
{
    public class ServiceType
    {
        public long Id { get; set; }
        [Required]
        public String Name { get; set; }
    }
}
