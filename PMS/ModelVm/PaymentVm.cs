using AutoMapper;
using PMS.Models;

namespace PMS.ModelVm
{
    [AutoMap(typeof(Payment),ReverseMap = true)]
    public class PaymentVm
    {
        public int Id { get; set; }
        public string TransId { get; set; }
        public string Email { get; set; }
        public string IsPaymentConfirm { get; set; }
        public string CartItems { get; set; }
        public string OrderTime { get; set; }
    }
}
