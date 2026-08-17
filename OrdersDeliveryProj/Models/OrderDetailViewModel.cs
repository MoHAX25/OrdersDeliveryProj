namespace OrdersDeliveryProj.Models
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string SenderCity { get; set; } = string.Empty;
        public string SenderAddress { get; set; } = string.Empty;
        public string RecipientCity { get; set; } = string.Empty;
        public string RecipientAddress { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
