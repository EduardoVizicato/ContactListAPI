using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Domain.Data.Models.Request
{
    public class ContactRequest
    {
        public string? Name { get; set; }
        public double Mobile { get; set; }
        public bool IsActive { get; set; }
    }
}
