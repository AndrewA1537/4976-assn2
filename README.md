# 4976-assn2

Brief description of your project.

## Features

-   **Feature 1**: Brief description of feature 1.
-   **Feature 2**: Brief description of feature 2.
-   ...

## Getting Started

### Prerequisites

-   .NET SDK (Specify the version, e.g., .NET 5, .NET 6).
-   Any other dependencies or software needed.

### Installation

1. **Clone the repository**:

    ```bash
     git clone https://github.com/AndrewA1537/4976-assn2.git
    ```

2. **Change directory** to the project directory:

    ```bash
    cd your-project-name
    ```

3. **Run the application**:
    ```bash
    dotnet watch
    ```

### App Building Steps

1.  **Create the .NET Blazor Server app**:

    ```bash
     dotnet new blazorserver --auth individual -o NonProfitApp
    ```

2.  **Create the .NET Class Library**:

    ```bash
    dotnet new classlib -o NonProfitLibrary
    ```

3.  **Create a .NET Solution file and add the projects to that solution**:

    ```bash
    dotnet new sln

    dotnet sln add NonProfitApp/NonProfitApp.csproj

    dotnet sln add NonProfitLibrary/NonProfitLibrary.csproj
    ```

4.  **Install the following packages in the Blazor Server app**:

    ```bash
    dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package CsvHelper
    ```

5.  **Open the project in VSC and open the solution explorer**:

    ![Alt text](vsc-solution-explorer.png)
    <br />
    <br />
    right click on the Blazor Server and add a reference to the Class Library

6.  **Open the NonProfitLibrary folder in VS Code. Delete Class1.cs, then create new Models for ContactList.cs, Donations.cs, PaymentMethod.cs and TransactionType.cs**:

    ```cs
    public class ContactList
    {
        [Key]
        public int AccountNo { get; set; }
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [StringLength(100)]
        public string? Street { get; set; }
        [StringLength(50)]
        public string? City { get; set; }
        [StringLength(6)]
        public string? PostalCode { get; set; }
        [StringLength(50)]
        public string? Country { get; set; }

        [ScaffoldColumn(false)] // This prevents the Created property from being scaffolded
        public DateTime Created { get; set; } = DateTime.Now;

        [ScaffoldColumn(false)] // This prevents the Modified property from being scaffolded
        public DateTime Modified { get; set; } = DateTime.Now;

        [ScaffoldColumn(false)] // This prevents the CreatedBy property from being scaffolded
        public string? CreatedBy { get; set; }

        [ScaffoldColumn(false)] // This prevents the ModifiedBy property from being scaffolded
        public string? ModifiedBy { get; set; }
    }



    public class Donations
    {
        [Key]
        public int TransId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int AccountNo { get; set; }
        [Required]
        public int TransactionTypeId { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public float Amount { get; set; }
        [Required]
        public int PaymentMethodId { get; set; }
        public string? Notes { get; set; }

        // [ScaffoldColumn(false)]
        public DateTime Created { get; set; } = DateTime.Now;

        // [ScaffoldColumn(false)]
        [Display(Name = "Last Modified")]
        public DateTime Modified { get; set; } = DateTime.Now;

        // REMOVE THE REQUIRED IF YOU WANT CONTROLLER TO WORK

        // [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        // [ScaffoldColumn(false)]
        public string ModifiedBy { get; set; }

        // Navigation properties
        [ForeignKey("AccountNo")]
        public ContactList? Account { get; set; }

        [ForeignKey("TransactionTypeId")]
        public TransactionType? TransactionType { get; set; }

        [ForeignKey("PaymentMethodId")]
        public PaymentMethod? PaymentMethod { get; set; }
    }



    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        // system stuff below
        [ScaffoldColumn(false)] // This prevents the Created property from being scaffolded
        public DateTime Created { get; set; } = DateTime.Now;

        [ScaffoldColumn(false)] // This prevents the Created property from being scaffolded
        public DateTime Modified { get; set; } = DateTime.Now;

        [ScaffoldColumn(false)] // This prevents the Created property from being scaffolded
        public string? CreatedBy { get; set; }

        [ScaffoldColumn(false)] // This prevents the Created property from being scaffolded
        public string? ModifiedBy { get; set; }
    }



    public class TransactionType
    {
        public int TransactionTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(100)]
        public string? Description { get; set; }

        [ScaffoldColumn(false)] // This prevents the Created property from being scaffolded
        public DateTime Created { get; set; } = DateTime.Now;

        [ScaffoldColumn(false)] // This prevents the Created property from being scaffolded
        public DateTime Modified { get; set; } = DateTime.Now;

        [ScaffoldColumn(false)] // This prevents the Created property from being scaffolded
        public string? CreatedBy { get; set; }

        [ScaffoldColumn(false)] // This prevents the Created property from being scaffolded
        public string? ModifiedBy { get; set; }
    }
    ```

7.  **We need to add a connection string for the database. Add the following to the top of the appsettings.json file**:

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "DataSource=app.db;Cache=Shared"
    },
    ```

8.  **In the Data folder in the Blazor Server add a ModelBuilderExtensions class**:

    ```cs
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            var pwd = "P@$$w0rd";
            var passwordHasher = new PasswordHasher<IdentityUser>();

            // Seed Roles
            var adminRole            = new IdentityRole("Admin");
            adminRole.NormalizedName = adminRole.Name!.ToUpper();

            var financeRole = new IdentityRole("Finance");
            financeRole.NormalizedName = financeRole.Name!.ToUpper();

            List<IdentityRole> roles = new List<IdentityRole>()
            {
                adminRole,
                financeRole
            };

            builder.Entity<IdentityRole>().HasData(roles);


            // Seed Users
            var adminUser = new IdentityUser
            {
                UserName       = "a@a.a",
                Email          = "a@a.a",
                EmailConfirmed = true,
            };
            adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
            adminUser.NormalizedEmail    = adminUser.Email.ToUpper();
            adminUser.PasswordHash       = passwordHasher.HashPassword(adminUser, pwd);


            var financeUser = new IdentityUser
            {
                UserName       = "f@f.f",
                Email          = "f@f.f",
                EmailConfirmed = true,
            };
            financeUser.NormalizedUserName = financeUser.UserName.ToUpper();
            financeUser.NormalizedEmail    = financeUser.Email.ToUpper();
            financeUser.PasswordHash       = passwordHasher.HashPassword(financeUser, pwd);

            List<IdentityUser> users = new List<IdentityUser>()
            {
                adminUser,
                financeUser,
            };

            builder.Entity<IdentityUser>().HasData(users);

            // Seed UserRoles
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(q => q.Name == "Finance").Id
            });


            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
    ```

9.  **In the Data folder in the Blazor Server add a SeedData class**:

    ```cs
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
                // CURRENT DATE TIME SEED DATA
                new Donations()
                {
                    TransId           = 4,
                    Date              = DateTime.Now,
                    AccountNo         = 1,
                    TransactionTypeId = 1,
                    Amount            = 1100,
                    PaymentMethodId   = 1,
                    Notes             = "Donation",
                    Created           = DateTime.Now,
                    Modified          = DateTime.Now,
                    CreatedBy         = "System",
                    ModifiedBy        = "System"
                    },
                new Donations()
                {
                    TransId           = 5,
                    Date              = DateTime.Now,
                    AccountNo         = 2,
                    TransactionTypeId = 2,
                    Amount            = 1200,
                    PaymentMethodId   = 2,
                    Notes             = "Event",
                    Created           = DateTime.Now,
                    Modified          = DateTime.Now,
                    CreatedBy         = "System",
                    ModifiedBy        = "System"
                },
                new Donations()
                {
                    TransId           = 6,
                    Date              = DateTime.Now,
                    AccountNo         = 3,
                    TransactionTypeId = 3,
                    Amount            = 1300,
                    PaymentMethodId   = 3,
                    Notes             = "Membership",
                    Created           = DateTime.Now,
                    Modified          = DateTime.Now,
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
    ```

10. **In the Data folder in the Blazor Server modify the ApplicationDbContext class**:

    ```cs
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
    ```
