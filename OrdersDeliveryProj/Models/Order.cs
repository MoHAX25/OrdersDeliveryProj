using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersDeliveryProj.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string OrderNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string SenderCity { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string SenderAddress { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string RecipientCity { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string RecipientAddress { get; set; } = string.Empty;

        [Required]
        [Range(0.1, 1000)]
        public decimal Weight { get; set; }

        [Required]
        public DateTime PickupDate { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
