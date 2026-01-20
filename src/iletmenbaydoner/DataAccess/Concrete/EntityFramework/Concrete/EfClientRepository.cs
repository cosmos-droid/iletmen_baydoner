using Microsoft.EntityFrameworkCore;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.DataAccess.Core;
using iletmenbaydoner.DataAccess.Abstract;

namespace iletmenbaydoner.DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfClientRepository : EfRepositoryBase<Client, iletmenbaydonerDatabaseContext>, IClientDal
    {
        public EfClientRepository(iletmenbaydonerDatabaseContext context) : base(context)
        {
        }
    }
}