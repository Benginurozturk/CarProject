using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        [SecuredOperation("user,rental.add,moderator,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(IsRentable(rental));
            if (result != null) return result;

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        [SecuredOperation("rental.update,moderator,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental customer)
        {
            _rentalDal.Update(customer);
            return new SuccessResult(Messages.RentalUpdated);
        }

        [SecuredOperation("rental.delete,moderator,admin")]
        public IResult Delete(Rental customer)
        {
            _rentalDal.Delete(customer);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarID == carId));
        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(x => x.CarID == carId && x.ReturnDate == null);
            if (result.Count > 0) return new ErrorResult(Messages.RentalUndeliveredCar);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult IsRentable(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarID == rental.CarID);

            if (result.Any(r =>
                r.RentEndDate >= rental.RentStartDate &&
                r.RentStartDate <= rental.RentEndDate
            )) return new ErrorResult(Messages.RentalNotAvailable);

            return new SuccessResult();
        }

        //[SecuredOperation("user,rental.add,moderator,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IDataResult<int> AddDto(RentalAddDto rentalAddDto)
        {
            Rental rentalToAdd = new Rental()
            {
                CarID = Convert.ToInt32(rentalAddDto.CarId),
                CustomerID = rentalAddDto.CustomerId,
                RentEndDate = rentalAddDto.RentEndDate,
                RentStartDate = rentalAddDto.RentStartDate,
                ReturnDate = rentalAddDto.ReturnDate
            };

            _rentalDal.Add(rentalToAdd);

            return new SuccessDataResult<int>(rentalToAdd.Id,Messages.RentalAdded);
        }
    }
}