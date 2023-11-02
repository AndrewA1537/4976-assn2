using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NonProfitApp.Data;
using NonProfitLibrary;

namespace NonProfitApp.Services;

[Authorize(Roles = "Admin")]
public class ContactListService
{
    private readonly ApplicationDbContext _context;

    public ContactListService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ContactList>> GetContactsAsync()
    {
        return await _context.ContactList.ToListAsync();
    }

    public async Task<ContactList?> GetContactByIdAsync(int id)
    {
        return await _context.ContactList
            .FirstOrDefaultAsync(m => m.AccountNo == id);
    }

    public async Task<ContactList> InsertContactAsync(ContactList contact)
    {
        _context.ContactList.Add(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task<ContactList?> UpdateContactAsync(int id, ContactList updatedContact)
    {
        var contact = await _context.ContactList.FindAsync(id);
        if (contact == null)
        {
            return null;
        }

        // Update the properties
        contact.FirstName = updatedContact.FirstName;
        contact.LastName = updatedContact.LastName;
        // ... Other properties

        _context.Update(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task<ContactList?> DeleteContactAsync(int id)
    {
        var contact = await _context.ContactList.FindAsync(id);
        if (contact == null)
        {
            return null;
        }

        _context.ContactList.Remove(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    private bool ContactListExists(int id)
    {
        return _context.ContactList.Any(e => e.AccountNo == id);
    }
}
