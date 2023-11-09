namespace NonProfitApp.Services;

[Authorize(Roles = "Admin")]
public class PaymentMethodService
{
    private readonly ApplicationDbContext _context;

    public PaymentMethodService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<PaymentMethod>> GetAllPaymentMethodsAsync()
    {
        return await _context.PaymentMethod.ToListAsync();
    }

    public async Task<PaymentMethod?> GetPaymentMethodByIdAsync(int id)
    {
        return await _context.PaymentMethod.FirstOrDefaultAsync(m => m.PaymentMethodId == id);
    }

    public async Task<PaymentMethod> CreatePaymentMethodAsync(PaymentMethod paymentMethod)
    {
        _context.Add(paymentMethod);
        await _context.SaveChangesAsync();
        return paymentMethod;
    }

    public async Task<PaymentMethod?> UpdatePaymentMethodAsync(int id, PaymentMethod updatedPaymentMethod)
    {
        var paymentMethod = await _context.PaymentMethod.FindAsync(id);
        if (paymentMethod == null) return null;

        paymentMethod.Name = updatedPaymentMethod.Name;
        // ... other fields if necessary

        _context.Update(paymentMethod);
        await _context.SaveChangesAsync();
        return paymentMethod;
    }

    public async Task<bool> DeletePaymentMethodAsync(int id)
    {
        var paymentMethod = await _context.PaymentMethod.FindAsync(id);
        if (paymentMethod == null) return false;

        _context.PaymentMethod.Remove(paymentMethod);
        await _context.SaveChangesAsync();
        return true;
    }

    private bool PaymentMethodExists(int id)
    {
        return _context.PaymentMethod.Any(e => e.PaymentMethodId == id);
    }
}
