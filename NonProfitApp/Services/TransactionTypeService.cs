namespace NonProfitApp.Services;

[Authorize(Roles = "Admin")]
public class TransactionTypeService
{
    private readonly ApplicationDbContext _context;

    public TransactionTypeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TransactionType>> GetAllTransactionTypesAsync()
    {
        return await _context.TransactionType.ToListAsync();
    }

    public async Task<TransactionType?> GetTransactionTypeByIdAsync(int id)
    {
        return await _context.TransactionType.FirstOrDefaultAsync(m => m.TransactionTypeId == id);
    }

    public async Task<TransactionType> CreateTransactionTypeAsync(TransactionType transactionType)
    {
        _context.Add(transactionType);
        await _context.SaveChangesAsync();
        return transactionType;
    }

    public async Task<TransactionType?> UpdateTransactionTypeAsync(int id, TransactionType updatedTransactionType)
    {
        var transactionType = await _context.TransactionType.FindAsync(id);
        if (transactionType == null) return null;

        transactionType.Name = updatedTransactionType.Name;
        transactionType.Description = updatedTransactionType.Description;
        // ... other fields if necessary

        _context.Update(transactionType);
        await _context.SaveChangesAsync();
        return transactionType;
    }

    public async Task<bool> DeleteTransactionTypeAsync(int id)
    {
        var transactionType = await _context.TransactionType.FindAsync(id);
        if (transactionType == null) return false;

        _context.TransactionType.Remove(transactionType);
        await _context.SaveChangesAsync();
        return true;
    }

    private bool TransactionTypeExists(int id)
    {
        return _context.TransactionType.Any(e => e.TransactionTypeId == id);
    }
}
