using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public int Id { get; set; }  
        public int RentalId { get; set; }
        public decimal TotalPrice { get; set; }
        public string CreditNumber { get; set; }
        public string NameOnCard { get; set; }
        public string CardCVV { get; set; }
    }
}
