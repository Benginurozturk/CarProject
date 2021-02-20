using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<Brand> GetCarsByBrandId(int brandId);

        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
    }
}
