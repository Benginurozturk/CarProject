using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            
        }

        //public static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    var result = carManager.GetCarDetails();
        //    if (result.Success == true)
        //    {
        //        foreach (var car in result.Data)
        //    {
        //            Console.WriteLine(car.BrandName + "/" + car.Description + "/" + car.ColorName + "/" + car.DailyPrice);

        //        }
        //    }

        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
        public  static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Marka......" + car.BrandName + "  Renk......" + car.ColorName + "  Fiyat....." + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }


}

