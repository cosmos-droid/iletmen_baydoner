
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Abstract
{
    public interface IProductGroupService
    {
        IDataResult<ProductGroup> GetProductGroupById(long productGroupId);
        IDataResult<IList<ProductGroup>> GetAllProductGroups();
        IResult AddProductGroup(ProductGroup productGroup);
        IResult UpdateProductGroup(ProductGroup productGroup);
        IResult DeleteProductGroup(ProductGroup productGroup);

    }
}