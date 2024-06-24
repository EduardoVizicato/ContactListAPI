using ContactList.Domain.Data.Models;
using ContactList.Domain.Data.Models.Request;
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

        public async Task<ContactRequest> Add(ContactRequest contactRequest)
        {
            var contact = new Contact()
            {
                Name = contactRequest.Name,
                Mobile = contactRequest.Mobile,
                IsActive = contactRequest.IsActive,
            };
            await _context.AddAsync(contact);
            await _context.SaveChangesAsync();

            var addedContactRequest = new ContactRequest()
            {
                Name = contact.Name,
                Mobile = contact.Mobile,
                IsActive = contact.IsActive,
            };

            return addedContactRequest;
        }

        public async Task<bool?> Delete(Guid id, ContactRequest contact)
        {
            var contactToUpdate = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            contactToUpdate.IsActive = false;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Contact>> GetAll()
        {
            var active = await _context.Contacts.Where(c => c.IsActive).ToListAsync();
            return  active;
        }

        public async Task<Contact> GetById(Guid id)
        {
            return await _context.Contacts.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool?> Update(Guid id, ContactRequest contact)
        {
            var contactToUpdate = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);

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
