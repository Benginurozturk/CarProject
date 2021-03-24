using System;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(PaymentAddDto paymentAddDto)
        {
            Payment paymentToAdd = new Payment()
            {
                NameOnCard = paymentAddDto.NameOnCard,
                CardCVV = paymentAddDto.CardCVV,
                CreditNumber = paymentAddDto.CreditNumber,
                TotalPrice = paymentAddDto.TotalPrice,
                RentalId = paymentAddDto.RentalId
            };

            _paymentDal.Add(paymentToAdd);

            return new SuccessResult(Messages.PaymentSuccessful);
        }

        public IResult test() // Test
        {
            var rd = new Random().Next(2);
            if (rd == 0) return new ErrorResult(Messages.PaymentFailed);

            return new SuccessResult(Messages.PaymentSuccessful);
        }
    }
}