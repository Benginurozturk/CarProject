using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
            else
            {
                return new ErrorResult(Messages.BrandDailyInValid);
            }
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);


        }
        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Update(brand);
                Console.WriteLine("Marka Güncellendi.");
            }
            else
            {
                Console.WriteLine("Marka adı en az 2 karakter olmalıdır.");
            }
            return new SuccessResult(Messages.BrandUpdated);
        }
        
       
        public IDataResult<Brand> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandID == brandId), Messages.BrandListed);
        }
    }
}
