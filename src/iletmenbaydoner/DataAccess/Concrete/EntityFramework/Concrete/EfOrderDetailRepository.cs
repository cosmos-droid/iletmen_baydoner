using Microsoft.EntityFrameworkCore;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.DataAccess.Core;
using iletmenbaydoner.DataAccess.Abstract;
using iletmenbaydoner.Entites.Concrete;

namespace iletmenbaydoner.DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfOrderDetailRepository : EfRepositoryBase<OrderDetail, iletmenbaydonerDatabaseContext>, IOrderDetailDal
    {
        public EfOrderDetailRepository(iletmenbaydonerDatabaseContext context) : base(context)
        {
        }
    }
}