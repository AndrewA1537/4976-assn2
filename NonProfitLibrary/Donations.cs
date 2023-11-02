using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NonProfitLibrary;

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
    public string? CreatedBy { get; set; }

    // [ScaffoldColumn(false)]
    public string? ModifiedBy { get; set; }

    // Navigation properties
    [ForeignKey("AccountNo")]
    public ContactList? Account { get; set; }

    [ForeignKey("TransactionTypeId")]
    public TransactionType? TransactionType { get; set; }

    [ForeignKey("PaymentMethodId")]
    public PaymentMethod? PaymentMethod { get; set; }
}
