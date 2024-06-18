using ContactList.Domain.Data.Models;
using ContactList.Domain.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Infrastructure.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDataContext _context;
        public ContactRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<Contact> Add(Contact contact)
        {
            await _context.AddAsync(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool?> Delete(Guid id, Contact contact)
        {
            var contactToUpdate = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            contactToUpdate.IsActive = false;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Contact>> GetAll()
        {
            var active =await _context.Contacts.Where(x=> x.IsActive).ToListAsync();
            return active;
        }

        public async Task<Contact> GetById(Guid id)
        {
            return await _context.Contacts.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool?> Update(Guid id, Contact contact)
        {
            var contactToUpdate = await GetById(contact.Id);

            if (contactToUpdate == null) {
               return null;
            }

            contactToUpdate.Name = contact.Name;
            contactToUpdate.Mobile = contact.Mobile;

            _context.Contacts.Update(contactToUpdate);

            return await _context.SaveChangesAsync() > 0;

        }
    }
}
