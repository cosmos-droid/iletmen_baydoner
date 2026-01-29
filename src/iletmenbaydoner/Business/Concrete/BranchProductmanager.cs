using iletmenbaydoner.Business.Abstract;
using iletmenbaydoner.Business.Constants;
using iletmenbaydoner.DataAccess.Abstract;
using iletmenbaydoner.Entites.Concrete;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Concrete
{
    public class BranchProductManager : IBranchProductService
    {
        private readonly IBranchProductDal _branchProductDal;
        private readonly IProductGroupTypeDal _productGroupTypeDal;
        private readonly IOrderDetailDal _orderDetailDal;
        private readonly IOrderHeaderDal _orderHeaderDal;

        public BranchProductManager(IBranchProductDal branchProductDal, IProductGroupTypeDal productGroupTypeDal,
        IOrderDetailDal orderDetailDal, IOrderHeaderDal orderHeaderDal)
        {
            _branchProductDal = branchProductDal;
            _productGroupTypeDal = productGroupTypeDal;
            _orderDetailDal = orderDetailDal;
            _orderHeaderDal = orderHeaderDal;
        }


        public IDataResult<BranchProduct> GetBranchProductById(long branchProductId)
        {
            try
            {
                return new SuccessDataResult<BranchProduct>(_branchProductDal.Get(bp => bp.BranchProductId == branchProductId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<BranchProduct>(message: ex.Message);
            }
        }


        public IResult AddBranchProduct(BranchProduct branchProduct)
        {
            try
            {
                branchProduct.ProductName = _productGroupTypeDal
                .Get(pd => pd.ProductGroupTypeId == branchProduct.ProductGroupTypeId)
                .ProductGroupTypeName;


                _branchProductDal.Add(branchProduct);
                return new SuccessResult(message: Messages.BranchProductAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }

        }


        public IResult DeleteBranchProduct(BranchProduct branchProduct)
        {
            try
            {
                _branchProductDal.Delete(branchProduct);
                return new SuccessResult(message: Messages.BranchProductDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }



        public IDataResult<IList<BranchProduct>> GetAllBranchProducts()
        {
            try
            {
                return new SuccessDataResult<IList<BranchProduct>>(_branchProductDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<BranchProduct>>(message: ex.Message);
            }
        }

        public IDataResult<IList<BranchProduct>> GetBranchProductsByBranchId(long branchId)
        {
            try
            {
                return new SuccessDataResult<IList<BranchProduct>>(_branchProductDal.GetAll(bp => bp.BranchId == branchId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<BranchProduct>>(message: ex.Message);
            }

        }



        public IResult UpdateBranchProduct(BranchProduct branchProduct)
        {
            try
            {

                branchProduct.ProductName = _productGroupTypeDal
                .Get(pd => pd.ProductGroupTypeId == branchProduct.ProductGroupTypeId)
                .ProductGroupTypeName;



                _branchProductDal.Update(branchProduct);
                return new SuccessResult(message: Messages.BranchProductUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }

        public IResult UpdateBranchProductStockQuantity(long branchProductId, int stockQuantity, string orderNo)
        {


            var branchProduct = _branchProductDal.Get(bp => bp.BranchProductId == branchProductId);
            if (branchProduct == null)
            {
                return new ErrorResult(message: Messages.BranchProductNotFound);
            }

            var _orderHeader = _orderHeaderDal.Get(oh => oh.OrderNo == orderNo);
            if (_orderHeader == null)
            {
                _orderHeader = new OrderHeader
                {
                    OrderNo = orderNo,
                    BranchId = branchProduct.BranchId,
                };
                _orderHeaderDal.Add(_orderHeader);
            }


            try
            {
                if (branchProduct.StockQuantity == 0 && stockQuantity < 0)
                {
                    branchProduct.StockQuantity = 0;
                    _branchProductDal.Update(branchProduct);
                    return new SuccessResult(message: branchProduct.ProductName + " " + "elimizde bulunmamaktadır.");
                }


                branchProduct.StockQuantity += stockQuantity;
                _branchProductDal.Update(branchProduct);

                if (stockQuantity < 0)
                {
                    for (int i = 0; i < Math.Abs(stockQuantity); i++)
                    {
                        var orderDetail = new OrderDetail
                        {
                            OrderNo = orderNo,
                            ProductGroupTypeId = branchProduct.ProductGroupTypeId,
                        };

                        _orderDetailDal.Add(orderDetail);
                    }
                }
                else
                {

                    for (int i = 0; i < Math.Abs(stockQuantity); i++)
                    {
                        var orderDetail = _orderDetailDal.GetAll(od => od.OrderNo == orderNo).FirstOrDefault();
                        _orderDetailDal.Delete(orderDetail);
                    }

                }

                return new SuccessResult(message: "BranchProductStockQuantityUpdated"); ;
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }


        }
    }
}