
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Abstract
{
    public interface IBranchProductService
    {
        IDataResult<BranchProduct> GetBranchProductById(long branchProductId);
        IDataResult<IList<BranchProduct>> GetBranchProductsByBranchId(long branchId);
        IDataResult<IList<BranchProduct>> GetAllBranchProducts();
        IResult UpdateBranchProductStockQuantity(long branchProductId, int stockQuantity, string orderNo);
        IResult AddBranchProduct(BranchProduct branchProduct);
        IResult UpdateBranchProduct(BranchProduct branchProduct);
        IResult DeleteBranchProduct(BranchProduct branchProduct);
    }
}