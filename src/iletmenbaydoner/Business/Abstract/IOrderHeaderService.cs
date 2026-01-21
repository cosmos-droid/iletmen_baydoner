
using iletmenbaydoner.Entites.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Abstract
{
    public interface IOrderHeaderService
    {
        IDataResult<OrderHeader> GetOrderHeaderById(long orderHeaderId);
        IDataResult<OrderHeader> GetOrderHeaderByOrderNo(string orderNo);
        IDataResult<IList<OrderHeader>> GetAllOrderHeaders();
        IDataResult<OrderHeader> AddAndGetOrderHeader(long branchId, string orderNo, string customerName, string customerAdress);
        IDataResult<OrderHeader> AddOrderHeader(OrderHeader orderHeader);
        IResult UpdateOrderHeader(OrderHeader orderHeader);
        IResult DeleteOrderHeader(OrderHeader orderHeader);
    }
}