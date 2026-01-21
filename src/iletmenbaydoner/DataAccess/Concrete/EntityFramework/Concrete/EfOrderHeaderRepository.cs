using Microsoft.EntityFrameworkCore;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.DataAccess.Core;
using iletmenbaydoner.DataAccess.Abstract;
using iletmenbaydoner.Entites.Concrete;

namespace iletmenbaydoner.DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfOrderHeaderRepository : EfRepositoryBase<OrderHeader, iletmenbaydonerDatabaseContext>, IOrderHeaderDal
    {
        public EfOrderHeaderRepository(iletmenbaydonerDatabaseContext context) : base(context)
        {
        }
    }
}