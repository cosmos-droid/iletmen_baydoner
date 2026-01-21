using iletmenbaydoner.Business.Abstract;
using iletmenbaydoner.Business.Constants;
using iletmenbaydoner.DataAccess.Abstract;
using iletmenbaydoner.Entites.Concrete;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Concrete
{
    public class OrderHeaderManager : IOrderHeaderService
    {
        private readonly IOrderHeaderDal _orderHeaderDal;

        public OrderHeaderManager(IOrderHeaderDal orderHeaderDal)
        {
            _orderHeaderDal = orderHeaderDal;
        }

        public IDataResult<OrderHeader> GetOrderHeaderById(long orderHeaderId)
        {
            try
            {
                return new SuccessDataResult<OrderHeader>(_orderHeaderDal.Get(c => c.OrderHeaderId == orderHeaderId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<OrderHeader>(message: ex.Message);
            }
        }

        public IDataResult<OrderHeader> GetOrderHeaderByOrderNo(string orderNo)
        {
            try
            {
                return new SuccessDataResult<OrderHeader>(_orderHeaderDal.Get(c => c.OrderNo == orderNo));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<OrderHeader>(message: ex.Message);
            }
        }


        public IDataResult<OrderHeader> AddOrderHeader(OrderHeader orderHeader)
        {
            try
            {
                _orderHeaderDal.Add(orderHeader);
                OrderHeader _orderHeader = _orderHeaderDal.Get(o => o.OrderHeaderId == orderHeader.OrderHeaderId);
                return new SuccessDataResult<OrderHeader>(_orderHeader);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<OrderHeader>(message: ex.Message);
            }

        }

        public IDataResult<OrderHeader> AddAndGetOrderHeader(long branchId, string orderNo, string customerName, string customerAdress)
        {
            try
            {
                OrderHeader orderHeader = new OrderHeader
                {
                    BranchId = branchId,
                    OrderNo = orderNo,
                    CustomerName = customerName,
                    CustomerAdress = customerAdress,
                };
                _orderHeaderDal.Add(orderHeader);
                return new SuccessDataResult<OrderHeader>(_orderHeaderDal.Get(c => c.OrderHeaderId == orderHeader.OrderHeaderId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<OrderHeader>(message: ex.Message);
            }
        }


        public IResult DeleteOrderHeader(OrderHeader orderHeader)
        {
            try
            {
                _orderHeaderDal.Delete(orderHeader);
                return new SuccessResult(message: Messages.OrderHeaderDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }



        public IDataResult<IList<OrderHeader>> GetAllOrderHeaders()
        {
            try
            {
                return new SuccessDataResult<IList<OrderHeader>>(_orderHeaderDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<OrderHeader>>(message: ex.Message);
            }
        }



        public IResult UpdateOrderHeader(OrderHeader orderHeader)
        {
            try
            {
                _orderHeaderDal.Update(orderHeader);
                return new SuccessResult(message: Messages.OrderHeaderUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }


    }



}