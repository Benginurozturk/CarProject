using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetCarDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                using (ReCapProjectContext Context = new ReCapProjectContext())
                {
                    var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                                 join c in context.Cars
                                 on r.CarId equals c.Id
                                 join cu in context.Customers
                                 on r.CustomerId equals cu.CustomerId
                                 join b in context.Brands
                                 on c.BrandId equals b.BrandId
                                 join u in context.Users
                                 on cu.UserId equals u.UserId
                                 select new RentalDetailDto
                                 {
                                     RentalId = r.RentalId,
                                     CarName = b.BrandName,
                                     CustomerName = cu.CustomerName,
                                     UserName = u.FirstName + " " + u.LastName,
                                     RentDate = r.RentDate,
                                     ReturnDate = r.ReturnDate
                                 };

                    return result.ToList();






                }
            }
        }
    }
}

