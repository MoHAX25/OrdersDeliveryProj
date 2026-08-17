namespace OrdersDeliveryProj.Models
{
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string SenderCity { get; set; } = string.Empty;
        public string RecipientCity { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
