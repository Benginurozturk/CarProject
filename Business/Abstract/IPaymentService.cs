﻿using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IPaymentService
    {
        IResult Pay(CreditCard creditCard);
    }
}
