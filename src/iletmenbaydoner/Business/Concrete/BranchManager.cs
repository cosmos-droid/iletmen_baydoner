using iletmenbaydoner.Business.Abstract;
using iletmenbaydoner.Business.Constants;
using iletmenbaydoner.DataAccess.Abstract;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Concrete
{
    public class BranchManager : IBranchService
    {
        private readonly IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }


        public IDataResult<Branch> GetBranchById(long branchId)
        {
            try
            {
                return new SuccessDataResult<Branch>(_branchDal.Get(b => b.BranchId == branchId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Branch>(message: ex.Message);
            }
        }

        public IDataResult<Branch> GetBranchByName(string branchName)
        {
         
            try
            {
                return new SuccessDataResult<Branch>(_branchDal.Get(b => b.BranchName == branchName));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Branch>(message: ex.Message);
            }        
        
        }




        public IResult AddBranch(Branch branch)
        {
            try
            {
                _branchDal.Add(branch);
                return new SuccessResult(message: Messages.BranchAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }

        }


        public IResult DeleteBranch(Branch branch)
        {
            try
            {
                _branchDal.Delete(branch);
                return new SuccessResult(message: Messages.BranchDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }



        public IDataResult<IList<Branch>> GetAllBranches()
        {
            try
            {
                return new SuccessDataResult<IList<Branch>>(_branchDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<Branch>>(message: ex.Message);
            }
        }

        public IDataResult<IList<Branch>> GetBranchesByClientId(long clientId)
        {
            try
            {
                return new SuccessDataResult<IList<Branch>>(_branchDal.GetAll(b => b.ClientId == clientId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<Branch>>(message: ex.Message);
            }

        }



        public IDataResult<IList<Branch>> GetBranchesByDistrictId(long districtId)
        {
            try
            {
                return new SuccessDataResult<IList<Branch>>(_branchDal.GetAll(b => b.DistrictId == districtId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<Branch>>(message: ex.Message);
            }
        }        



        public IResult UpdateBranch(Branch branch)
        {
            try
            {
                _branchDal.Update(branch);
                return new SuccessResult(message: Messages.BranchUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }


    }



}