using iletmenbaydoner.Business.Abstract;
using iletmenbaydoner.Business.Constants;
using iletmenbaydoner.DataAccess.Abstract;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Concrete
{
    public class BranchProductManager : IBranchProductService
    {
        private readonly IBranchProductDal _branchProductDal;
        private readonly IProductGroupTypeDal _productGroupTypeDal;

        public BranchProductManager(IBranchProductDal branchProductDal, IProductGroupTypeDal productGroupTypeDal)
        {
            _branchProductDal = branchProductDal;
            _productGroupTypeDal = productGroupTypeDal;
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
    }



}