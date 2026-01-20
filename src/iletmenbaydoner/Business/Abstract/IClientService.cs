
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Abstract
{
    public interface IClientService
    {
        IDataResult<Client> GetClientById(long clientId);
        IDataResult<IList<Client>> GetAllClients();
        IResult AddClient(Client client);
        IResult UpdateClient(Client client);
        IResult DeleteClient(Client client);

    }
}