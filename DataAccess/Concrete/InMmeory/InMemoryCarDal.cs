using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMmeory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public readonly Car car;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {

                new Car{Id = 1, BrandId = 1, ColorId=15,ModelYear=2010, DailyPrice=400, Description ="Aston Martin V8 Vantage - Turuncu"},
                new Car{Id = 2, BrandId = 2, ColorId=1,ModelYear=2017, DailyPrice=300, Description ="Peugeot V8 Vantage - siyah"},
                new Car{Id = 3, BrandId = 3, ColorId=2,ModelYear=2009, DailyPrice=2000, Description ="Ferrari 430 Scuderia - Kırmızı"},
                new Car{Id = 4, BrandId = 4, ColorId=1,ModelYear=1966, DailyPrice=1000, Description ="Ford Mustang  - Beyaz"},
                new Car{Id = 5, BrandId = 5, ColorId=5,ModelYear=1983, DailyPrice=250, Description ="Buik Enclave - Sarı"},
                new Car{Id = 6, BrandId = 6, ColorId=8,ModelYear=2019, DailyPrice=600, Description ="Volvo C30 - Kahverengi"}
            };
        }
        public void Add(Car Car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;

            carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.Id == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUptade = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUptade.Id = car.Id;
            carToUptade.ColorId = car.ColorId;
            carToUptade.BrandId = car.BrandId;
            carToUptade.ColorId = car.ColorId;
            carToUptade.Description = car.Description;
            carToUptade.ModelYear = car.ModelYear;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        List<CarDetailDto> ICarDal.GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
