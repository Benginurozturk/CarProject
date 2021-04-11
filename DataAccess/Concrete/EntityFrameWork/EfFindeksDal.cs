using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFindeksDal : EfEntityRepositoryBase<Findeks, ReCapProjectContext>, IFindeksDal
    {
    }
}
