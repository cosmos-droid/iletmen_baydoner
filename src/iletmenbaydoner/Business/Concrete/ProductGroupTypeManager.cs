using iletmenbaydoner.Business.Abstract;
using iletmenbaydoner.Business.Constants;
using iletmenbaydoner.DataAccess.Abstract;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Concrete
{
    public class ProductGroupTypeManager : IProductGroupTypeService
    {
        private readonly IProductGroupTypeDal _productGroupTypeDal;

        public ProductGroupTypeManager(IProductGroupTypeDal productGroupTypeDal)
        {
            _productGroupTypeDal = productGroupTypeDal;
        }


        public IDataResult<ProductGroupType> GetProductGroupTypeById(long productGroupTypeId)
        {
            try
            {
                return new SuccessDataResult<ProductGroupType>(_productGroupTypeDal.Get(p => p.ProductGroupTypeId == productGroupTypeId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ProductGroupType>(message: ex.Message);
            }
        }


        public IResult AddProductGroupType(ProductGroupType productGroupType)
        {
            try
            {
                _productGroupTypeDal.Add(productGroupType);
                return new SuccessResult(message: Messages.ProductGroupTypeAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }

        }


        public IResult DeleteProductGroupType(ProductGroupType productGroupType)
        {
            try
            {
                _productGroupTypeDal.Delete(productGroupType);
                return new SuccessResult(message: Messages.ProductGroupTypeDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }



        public IDataResult<IList<ProductGroupType>> GetAllProductGroupTypes()
        {
            try
            {
                return new SuccessDataResult<IList<ProductGroupType>>(_productGroupTypeDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<ProductGroupType>>(message: ex.Message);
            }
        }


        public IDataResult<IList<ProductGroupType>> GetProductGroupTypesByProductGroupId(long productGroupId)
        {
            try
            {
                return new SuccessDataResult<IList<ProductGroupType>>(_productGroupTypeDal.GetAll(p => p.ProductGroupId == productGroupId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<ProductGroupType>>(message: ex.Message);
            }
        }


        public IResult UpdateProductGroupType(ProductGroupType productGroupType)
        {
            try
            {
                _productGroupTypeDal.Update(productGroupType);
                return new SuccessResult(message: Messages.ProductGroupTypeUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }


    }



}