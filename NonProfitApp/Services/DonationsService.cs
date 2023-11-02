using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NonProfitApp.Data;
using NonProfitLibrary;

namespace NonProfitApp.Services;

public class DonationsService
{
    private readonly ApplicationDbContext _context;

    public DonationsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Donations>> GetAllDonationsAsync()
    {
        return await _context.Donations
                            .Include(d => d.Account)
                            .Include(d => d.PaymentMethod)
                            .Include(d => d.TransactionType)
                            .ToListAsync();
    }

    public async Task<Donations?> GetDonationByIdAsync(int id)
    {
        return await _context.Donations
                            .Include(d => d.Account)
                            .Include(d => d.PaymentMethod)
                            .Include(d => d.TransactionType)
                            .FirstOrDefaultAsync(m => m.TransId == id);
    }

    public async Task<Donations> CreateDonationAsync(Donations donation)
    {
        // Set the creation and modification data here if needed
        donation.Created = DateTime.Now;
        donation.Modified = DateTime.Now;
        // donation.CreatedBy and ModifiedBy should be set based on the current user

        _context.Donations.Add(donation);
        await _context.SaveChangesAsync();
        return donation;
    }

    public async Task<Donations?> UpdateDonationAsync(int id, Donations updatedDonation)
    {
        var donation = await _context.Donations.FindAsync(id);
        if (donation == null) return null;

        // Update the fields of donation
        donation.Date = updatedDonation.Date;
        donation.AccountNo = updatedDonation.AccountNo;
        // ... other fields
        donation.Modified = DateTime.Now;
        // donation.ModifiedBy should be updated based on the current user

        _context.Donations.Update(donation);
        await _context.SaveChangesAsync();
        return donation;
    }

    public async Task<bool> DeleteDonationAsync(int id)
    {
        var donation = await _context.Donations.FindAsync(id);
        if (donation == null) return false;

        _context.Donations.Remove(donation);
        await _context.SaveChangesAsync();
        return true;
    }

    private bool DonationExists(int id)
    {
        return _context.Donations.Any(e => e.TransId == id);
    }
}
