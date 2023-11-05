using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NonProfitApp.Data;
using NonProfitLibrary;

namespace NonProfitApp.Services;

[Authorize(Roles = "Admin, Finance")]
public class DonationsService
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DonationsService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;

    }

    private string GetCurrentUserId()
    {
        // If the resulting value is null, return an empty string or a default string
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
    }

    private string GetCurrentUserName()
    {
        // If the resulting value is null, return an empty string or a default string
        return _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Anonymous";
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
        string currentUserName = GetCurrentUserName(); // Gets the current user's name


        // Set the creation and modification data here if needed
        donation.Created = DateTime.Now;
        donation.Modified = DateTime.Now;
        // donation.CreatedBy and ModifiedBy should be set based on the current user
        donation.CreatedBy = currentUserName; // Set based on the current user's name
        donation.ModifiedBy = currentUserName; // You can also separate this if different logic is needed for ModifiedBy

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
