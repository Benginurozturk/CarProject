using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfPaymentDal : EfEntityRepositoryBase<Payment, ReCapProjectContext>, IPaymentDal
    {

    }
}
