using Microsoft.EntityFrameworkCore;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.DataAccess.Core;
using iletmenbaydoner.DataAccess.Abstract;

namespace iletmenbaydoner.DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfProductGroupRepository : EfRepositoryBase<ProductGroup, iletmenbaydonerDatabaseContext>, IProductGroupDal
    {
        public EfProductGroupRepository(iletmenbaydonerDatabaseContext context) : base(context)
        {
        }
    }
}