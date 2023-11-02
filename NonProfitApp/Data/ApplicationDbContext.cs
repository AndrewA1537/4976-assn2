using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NonProfitLibrary;

namespace NonProfitApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<ContactList> ContactList { get; set; } = default!;
    public DbSet<TransactionType> TransactionType { get; set; } = default!;
    public DbSet<PaymentMethod> PaymentMethod { get; set; } = default!;
    public DbSet<Donations> Donations { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ContactList>().ToTable("ContactList");
        builder.Entity<Donations>().ToTable("Donations");
        builder.Entity<PaymentMethod>().ToTable("PaymentMethod");
        builder.Entity<TransactionType>().ToTable("TransactionType");

        // seed the database
        SeedData.Seed(builder);

        // seed the users and roles
        ModelBuilderExtensions.Seed(builder);
    }
}
