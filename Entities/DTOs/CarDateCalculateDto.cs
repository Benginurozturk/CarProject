using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDateCalculateDto:IDto
    { 
        public int CarId { get; set; }
        public DateTime RentDate { get; set; } 
        public DateTime ReturnDate { get; set; }
    }
}
