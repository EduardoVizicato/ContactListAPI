using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Domain.Data.Models
{
    public class Contact
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public int Mobile {get; set; }
        public bool IsActive { get; set; }
    }
}
