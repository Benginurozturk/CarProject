﻿using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<Rental> GetById(int id);

        IDataResult<List<Rental>> GetAll();

        IDataResult<List<Rental>> GetAllByCarId(int carId);

        IResult Add(Rental rental);

        IResult AddDto(RentalAddDto rentalAddDto);

        IResult Update(Rental rental);

        IResult Delete(Rental rental);

        IResult CheckReturnDate(int carId);

        IResult IsRentable(Rental rental);
    }
}