using System;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Concrete
{
    public class FakePaymentManager : IPaymentService
    {
        //public IResult Add(PaymentAddDto paymentAddDto)
        //{
        //    throw new NotImplementedException();
        //}

        public IResult Payment()
        {
            var rd = new Random().Next(2);
            if (rd == 0) return new ErrorResult(Messages.PaymentFailed);

            return new SuccessResult(Messages.PaymentSuccessful);
        }

        public IResult test()
        {
            throw new NotImplementedException();
        }
    }
}