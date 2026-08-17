using System.ComponentModel.DataAnnotations;

namespace OrdersDeliveryProj.Models
{
    public class CreateOrderViewModel
    {
        [Required(ErrorMessage = "Город отправителя обязателен")]
        [StringLength(100, ErrorMessage = "Максимум 100 символов")]
        [Display(Name = "Город отправителя")]
        public string SenderCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Адрес отправителя обязателен")]
        [StringLength(255, ErrorMessage = "Максимум 255 символов")]
        [Display(Name = "Адрес отправителя")]
        public string SenderAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Город получателя обязателен")]
        [StringLength(100, ErrorMessage = "Максимум 100 символов")]
        [Display(Name = "Город получателя")]
        public string RecipientCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Адрес получателя обязателен")]
        [StringLength(255, ErrorMessage = "Максимум 255 символов")]
        [Display(Name = "Адрес получателя")]
        public string RecipientAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Вес груза обязателен")]
        [Range(0.1, 1000, ErrorMessage = "Вес должен быть от 0.1 до 1000 кг")]
        [Display(Name = "Вес груза (кг)")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Дата забора груза обязательна")]
        [Display(Name = "Дата забора груза")]
        [DataType(DataType.DateTime)]
        public DateTime PickupDate { get; set; } = DateTime.Now.Date.AddHours(10);
    }
}
