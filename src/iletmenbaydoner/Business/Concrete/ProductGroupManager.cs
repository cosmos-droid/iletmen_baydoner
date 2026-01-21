using iletmenbaydoner.Business.Abstract;
using iletmenbaydoner.Business.Constants;
using iletmenbaydoner.DataAccess.Abstract;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Concrete
{
    public class ProductGroupManager : IProductGroupService
    {
        private readonly IProductGroupDal _productGroupDal;

        public ProductGroupManager(IProductGroupDal productGroupDal)
        {
            _productGroupDal = productGroupDal;
        }


        public IDataResult<ProductGroup> GetProductGroupById(long productGroupId)
        {
            try
            {
                return new SuccessDataResult<ProductGroup>(_productGroupDal.Get(p => p.ProductGroupId == productGroupId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ProductGroup>(message: ex.Message);
            }
        }


        public IResult AddProductGroup(ProductGroup productGroup)
        {
            try
            {
                _productGroupDal.Add(productGroup);
                return new SuccessResult(message: Messages.ProductGroupAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }

        }


        public IResult DeleteProductGroup(ProductGroup productGroup)
        {
            try
            {
                _productGroupDal.Delete(productGroup);
                return new SuccessResult(message: Messages.ProductGroupDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }



        public IDataResult<IList<ProductGroup>> GetAllProductGroups()
        {
            try
            {
                return new SuccessDataResult<IList<ProductGroup>>(_productGroupDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<ProductGroup>>(message: ex.Message);
            }
        }



        public IResult UpdateProductGroup(ProductGroup productGroup)
        {
            try
            {
                _productGroupDal.Update(productGroup);
                return new SuccessResult(message: Messages.ProductGroupUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }
    }



}