using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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
                                 on r.CarID equals c.CarID
                                 join cu in context.Customers
                                 on r.CustomerID equals cu.CustomerID
                                 join b in context.Brands
                                 on c.BrandID equals b.BrandID
                                 join u in context.Users
                                 on cu.UserID equals u.UserID
                                 select new RentalDetailDto
                                 {
                                     RentalID = r.RentalID,
                                     CarName = b.BrandName,
                                     CompanyName = cu.CompanyName,
                                     UserName = u.UserFirstName + u.UserLastName,
                                     RentDate = r.RentDate,
                                     ReturnDate = r.ReturnDate,
                                     FirstName = u.UserFirstName,
                                     LastName = u.UserLastName
                                 };

                    return result.ToList();






                }
            }
        }
    }
}

