using iletmenbaydoner.Business.Abstract;
using iletmenbaydoner.Business.Constants;
using iletmenbaydoner.DataAccess.Abstract;
using iletmenbaydoner.Entites.Concrete;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public IDataResult<OrderDetail> GetOrderDetailById(long orderDetailId)
        {
            try
            {
                return new SuccessDataResult<OrderDetail>(_orderDetailDal.Get(c => c.OrderDetailId == orderDetailId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<OrderDetail>(message: ex.Message);
            }
        }



        public IResult AddOrderDetail(OrderDetail orderDetail)
        {
            {
                try
                {
                    _orderDetailDal.Add(orderDetail);
                    return new SuccessResult(message: Messages.OrderDetailAdded);
                }
                catch (Exception ex)
                {
                    return new ErrorResult(message: ex.Message);
                }

            }
        }


        public IResult DeleteOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _orderDetailDal.Delete(orderDetail);
                return new SuccessResult(message: Messages.OrderDetailDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }



        public IDataResult<IList<OrderDetail>> GetAllOrderDetails()
        {
            try
            {
                return new SuccessDataResult<IList<OrderDetail>>(_orderDetailDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<OrderDetail>>(message: ex.Message);
            }
        }

        public IDataResult<IList<OrderDetail>> GetOrderDetailsByOrderNo(string orderNo)
        {
            try
            {
                return new SuccessDataResult<IList<OrderDetail>>(_orderDetailDal.GetAll(o => o.OrderNo == orderNo));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<OrderDetail>>(message: ex.Message);
            }
        }




        public IResult UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _orderDetailDal.Update(orderDetail);
                return new SuccessResult(message: Messages.OrderDetailUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }


    }



}