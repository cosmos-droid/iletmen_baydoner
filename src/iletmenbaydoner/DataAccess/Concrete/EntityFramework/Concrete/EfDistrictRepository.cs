using Microsoft.EntityFrameworkCore;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.DataAccess.Core;
using iletmenbaydoner.DataAccess.Abstract;

namespace iletmenbaydoner.DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfDistrictRepository : EfRepositoryBase<District, iletmenbaydonerDatabaseContext>, IDistrictDal
    {
        public EfDistrictRepository(iletmenbaydonerDatabaseContext context) : base(context)
        {
        }
    }
}