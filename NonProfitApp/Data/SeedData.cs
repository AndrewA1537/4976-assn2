namespace NonProfitApp.Data;

public static class SeedData
{
    // this is an extension method to the ModelBuilder class
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactList>().HasData(
            GetContactList()
        );
        modelBuilder.Entity<TransactionType>().HasData(
            GetTransactionType()
        );
        modelBuilder.Entity<PaymentMethod>().HasData(
            GetPaymentMethod()
        );
        modelBuilder.Entity<Donations>().HasData(
            GetDonations()
        );
    }

    public static List<ContactList> GetContactList()
    {
        List<ContactList> contacts = new List<ContactList>()
            {
                new ContactList()
                {
                    AccountNo  = 1,
                    FirstName  = "John",
                    LastName   = "Doe",
                    Email      = "john@email.com",
                    Street     = "123 Main St",
                    City       = "Anytown",
                    PostalCode = "12345",
                    Country    = "USA",
                    Created    = DateTime.Now,
                    Modified   = DateTime.Now,
                    CreatedBy  = "System",
                    ModifiedBy = "System"
                },
                new ContactList()
                {
                    AccountNo = 2,
                    FirstName  = "Jane",
                    LastName   = "Doe",
                    Email      = "jane@email.com",
                    Street     = "123 Main St",
                    City       = "Anytown",
                    PostalCode = "12345",
                    Country    = "USA",
                    Created    = DateTime.Now,
                    Modified   = DateTime.Now,
                    CreatedBy  = "System",
                    ModifiedBy = "System"
                },
                new ContactList()
                {
                    AccountNo  = 3,
                    FirstName  = "Bob",
                    LastName   = "Smith",
                    Email      = "Bob@email.com",
                    Street     = "123 Main St",
                    City       = "Anytown",
                    PostalCode = "12345",
                    Country    = "CAN",
                    Created    = DateTime.Now,
                    Modified   = DateTime.Now,
                    CreatedBy  = "System",
                    ModifiedBy = "System"
                }
            };
        return contacts;
    }

    public static List<TransactionType> GetTransactionType()
    {
        List<TransactionType> transactionTypes = new List<TransactionType>()
            {
                new TransactionType()
                    {
                        TransactionTypeId = 1,
                        Name              = "Donation",
                        Description       = "Donation",
                        Created           = DateTime.Now,
                        Modified          = DateTime.Now,
                        CreatedBy         = "System",
                        ModifiedBy        = "System"
                    },
                    new TransactionType()
                    {
                        TransactionTypeId = 2,
                        Name              = "Membership",
                        Description       = "Membership",
                        Created           = DateTime.Now,
                        Modified          = DateTime.Now,
                        CreatedBy         = "System",
                        ModifiedBy        = "System"
                    },
                    new TransactionType()
                    {
                        TransactionTypeId = 3,
                        Name              = "Event",
                        Description       = "Event",
                        Created           = DateTime.Now,
                        Modified          = DateTime.Now,
                        CreatedBy         = "System",
                        ModifiedBy        = "System"
                    }
            };
        return transactionTypes;
    }

    public static List<PaymentMethod> GetPaymentMethod()
    {
        List<PaymentMethod> paymentMethods = new List<PaymentMethod>()
            {
                new PaymentMethod()
                    {
                        PaymentMethodId = 1,
                        Name            = "Cash",
                        Created         = DateTime.Now,
                        Modified        = DateTime.Now,
                        CreatedBy       = "System",
                        ModifiedBy      = "System"
                    },
                    new PaymentMethod()
                    {
                        PaymentMethodId = 2,
                        Name            = "Check",
                        Created         = DateTime.Now,
                        Modified        = DateTime.Now,
                        CreatedBy       = "System",
                        ModifiedBy      = "System"
                    },
                    new PaymentMethod()
                    {
                        PaymentMethodId = 3,
                        Name            = "Credit Card",
                        Created         = DateTime.Now,
                        Modified        = DateTime.Now,
                        CreatedBy       = "System",
                        ModifiedBy      = "System"
                    }
            };
        return paymentMethods;
    }

    public static List<Donations> GetDonations()
    {
        List<Donations> donations = new List<Donations>()
        {
            // 2023 SEED DATA
            new Donations()
            {
                TransId           = 4,
                Date              = new DateTime(2023, 1, 15), // January 15, 2023
                AccountNo         = 1,
                TransactionTypeId = 1,
                Amount            = 1100,
                PaymentMethodId   = 1,
                Notes             = "Donation",
                Created           = new DateTime(2023, 1, 15), // January 15, 2023
                Modified          = new DateTime(2023, 1, 15), // January 15, 2023
                CreatedBy         = "System",
                ModifiedBy        = "System"
                },
            new Donations()
            {
                TransId           = 5,
                Date              = new DateTime(2023, 6, 20), // June 20, 2023
                AccountNo         = 2,
                TransactionTypeId = 2,
                Amount            = 1200,
                PaymentMethodId   = 2,
                Notes             = "Event",
                Created           = new DateTime(2023, 6, 20), // June 20, 2023
                Modified          = new DateTime(2023, 6, 20), // June 20, 2023
                CreatedBy         = "System",
                ModifiedBy        = "System"
            },
            new Donations()
            {
                TransId           = 6,
                Date              = new DateTime(2023, 11, 1), // November 1, 2023
                AccountNo         = 3,
                TransactionTypeId = 3,
                Amount            = 1300,
                PaymentMethodId   = 3,
                Notes             = "Membership",
                Created           = new DateTime(2023, 11, 1), // November 1, 2023
                Modified          = new DateTime(2023, 11, 1), // November 1, 2023
                CreatedBy         = "System",
                ModifiedBy        = "System"
            },
            // 2022 SEED DATA
            new Donations()
            {
                TransId           = 1,
                Date              = new DateTime(2022, 1, 15), // January 15, 2022
                AccountNo         = 1,
                TransactionTypeId = 1,
                Amount            = 100,
                PaymentMethodId   = 1,
                Notes             = "Donation",
                Created           = new DateTime(2022, 1, 15), // January 15, 2022
                Modified          = new DateTime(2022, 1, 15), // January 15, 2022
                CreatedBy         = "System",
                ModifiedBy        = "System"
                },
            new Donations()
            {
                TransId           = 2,
                Date              = new DateTime(2022, 6, 20), // June 20, 2022
                AccountNo         = 2,
                TransactionTypeId = 2,
                Amount            = 200,
                PaymentMethodId   = 2,
                Notes             = "Event",
                Created           = new DateTime(2022, 6, 20), // June 20, 2022
                Modified          = new DateTime(2022, 6, 20), // June 20, 2022
                CreatedBy         = "System",
                ModifiedBy        = "System"
            },
            new Donations()
            {
                TransId           = 3,
                Date              = new DateTime(2022, 12, 5), // December 5, 2022
                AccountNo         = 3,
                TransactionTypeId = 3,
                Amount            = 300,
                PaymentMethodId   = 3,
                Notes             = "Membership",
                Created           = new DateTime(2022, 12, 5), // December 5, 2022
                Modified          = new DateTime(2022, 12, 5), // December 5, 2022
                CreatedBy         = "System",
                ModifiedBy        = "System"
            }
        };
        return donations;
    }
}
