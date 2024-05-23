using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Domain.Data.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Mobile {get; set; } 
        public bool IsActive { get; set; } 
    }
}
