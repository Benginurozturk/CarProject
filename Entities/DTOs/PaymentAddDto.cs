using Core;

namespace Entities.DTOs
{
    public class PaymentAddDto : IDto
    {
        public int RentalId { get; set; }
        public decimal TotalPrice { get; set; }
        public string CreditNumber { get; set; }
        public string NameOnCard { get; set; }
        public string CardCVV { get; set; }
    }
}
