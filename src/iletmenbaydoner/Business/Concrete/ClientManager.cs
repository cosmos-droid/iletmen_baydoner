using iletmenbaydoner.Business.Abstract;
using iletmenbaydoner.Business.Constants;
using iletmenbaydoner.DataAccess.Abstract;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Concrete
{
    public class ClientManager : IClientService
    {
        private readonly IClientDal _clientDal;

        public ClientManager(IClientDal clientDal)
        {
            _clientDal = clientDal;
        }



        public IResult AddClient(Client client)
        {
            try
            {
                _clientDal.Add(client);
                return new SuccessResult(message: Messages.ClientAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }

        }


        public IResult DeleteClient(Client client)
        {
            try
            {
                _clientDal.Delete(client);
                return new SuccessResult(message: Messages.ClientDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }



        public IDataResult<IList<Client>> GetAllClients()
        {
            try
            {
                return new SuccessDataResult<IList<Client>>(_clientDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<Client>>(message: ex.Message);
            }
        }

        public IDataResult<Client> GetClientById(long clientId)
        {
            try
            {
                return new SuccessDataResult<Client>(_clientDal.Get(c => c.ClientId == clientId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Client>(message: ex.Message);
            }
        }


        public IResult UpdateClient(Client client)
        {
            try
            {
                _clientDal.Update(client);
                return new SuccessResult(message: Messages.ClientUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }
    }



}