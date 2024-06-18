using ContactList.Domain.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Domain.Data.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(Guid id);
        Task<bool?> Update(Guid id, Contact contact);
        Task<bool?> Delete(Guid id, Contact contact);
        Task<Contact> Add(Contact contact);
    }
}
