using System;
using System.ComponentModel.DataAnnotations;

namespace DeliveryOrderApp.Web.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Город отправителя обязателен")]
        [Display(Name = "Город отправителя")]
        public string SenderCity { get; set; }

        [Required(ErrorMessage = "Адрес отправителя обязателен")]
        [Display(Name = "Адрес отправителя")]
        public string SenderAddress { get; set; }

        [Required(ErrorMessage = "Город получателя обязателен")]
        [Display(Name = "Город получателя")]
        public string ReceiverCity { get; set; }

        [Required(ErrorMessage = "Адрес получателя обязателен")]
        [Display(Name = "Адрес получателя")]
        public string ReceiverAddress { get; set; }

        [Required(ErrorMessage = "Вес груза обязателен")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Вес должен быть больше 0")]
        [Display(Name = "Вес груза (кг)")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Дата забора груза обязательна")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата забора груза")]
        public DateTime PickupDate { get; set; }
    }
}