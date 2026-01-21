
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Abstract
{
    public interface IBranchService
    {
        IDataResult<Branch> GetBranchById(long branchId);
        IDataResult<IList<Branch>> GetBranchesByClientId(long clientId);
        IDataResult<IList<Branch>> GetAllBranches();
        IResult AddBranch(Branch branch);
        IResult UpdateBranch(Branch branch);
        IResult DeleteBranch(Branch branch);
    }
}