
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Abstract
{
    public interface IProductGroupTypeService
    {
        IDataResult<ProductGroupType> GetProductGroupTypeById(long productGroupTypeId);
        IDataResult<IList<ProductGroupType>> GetAllProductGroupTypes();
        IDataResult<IList<ProductGroupType>> GetProductGroupTypesByProductGroupId(long productGroupId);
        IResult AddProductGroupType(ProductGroupType productGroupType);
        IResult UpdateProductGroupType(ProductGroupType productGroupType);
        IResult DeleteProductGroupType(ProductGroupType productGroupType);

    }
}