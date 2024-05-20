using ContactList.Domain.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Infrastructure.Data
{
    public class ApplicationDataContext (DbContextOptions<ApplicationDataContext> options) : DbContext(options)
    {
        public DbSet<Contact> Contacts{ get; set; }
    }
}
