
using iletmenbaydoner.Entites.Concrete;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Abstract
{
    public interface IOrderDetailService
    {
        IDataResult<OrderDetail> GetOrderDetailById(long orderDetailId);
        IDataResult<IList<OrderDetail>> GetAllOrderDetails();
        IDataResult<IList<OrderDetail>> GetOrderDetailsByOrderHeaderNo(string orderHeaderNo);
        IResult AddOrderDetail(OrderDetail orderDetail);
        IResult UpdateOrderDetail(OrderDetail orderDetail);
        IResult DeleteOrderDetail(OrderDetail orderDetail);
    }
}