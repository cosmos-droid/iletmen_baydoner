using Microsoft.EntityFrameworkCore;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.DataAccess.Core;
using iletmenbaydoner.DataAccess.Abstract;

namespace iletmenbaydoner.DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfProductGroupTypeRepository : EfRepositoryBase<ProductGroupType, iletmenbaydonerDatabaseContext>, IProductGroupTypeDal
    {
        public EfProductGroupTypeRepository(iletmenbaydonerDatabaseContext context) : base(context)
        {
        }
    }
}