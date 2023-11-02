using System.ComponentModel.DataAnnotations;

namespace NonProfitLibrary;

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
