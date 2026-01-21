using Microsoft.EntityFrameworkCore;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.DataAccess.Core;
using iletmenbaydoner.DataAccess.Abstract;

namespace iletmenbaydoner.DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfBranchProductRepository : EfRepositoryBase<BranchProduct, iletmenbaydonerDatabaseContext>, IBranchProductDal
    {
        public EfBranchProductRepository(iletmenbaydonerDatabaseContext context) : base(context)
        {
        }
    }
}