using iletmenbaydoner.Business.Abstract;
using iletmenbaydoner.Business.Constants;
using iletmenbaydoner.DataAccess.Abstract;
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Concrete
{
    public class DistrictManager : IDistrictService
    {
        private readonly IDistrictDal _districtDal;

        public DistrictManager(IDistrictDal districtDal)
        {
            _districtDal = districtDal;
        }

        public IDataResult<District> GetDistrictById(long districtId)
        {
            try
            {
                return new SuccessDataResult<District>(_districtDal.Get(d => d.DistrictId == districtId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<District>(message: ex.Message);
            }
        }

        public IDataResult<District> GetDistrictByName(string districtName)
        {
            try
            {
                return new SuccessDataResult<District>(_districtDal.Get(d => d.DistrictName == districtName));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<District>(message: ex.Message);
            }
        }

        public IResult AddDistrict(District district)
        {
            try
            {
                _districtDal.Add(district);
                return new SuccessResult(message: Messages.DistrictAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }

        }


        public IResult DeleteDistrict(District district)
        {
            try
            {
                _districtDal.Delete(district);
                return new SuccessResult(message: Messages.DistrictDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }



        public IDataResult<IList<District>> GetAllDistricts()
        {
            try
            {
                return new SuccessDataResult<IList<District>>(_districtDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<District>>(message: ex.Message);
            }
        }




        public IResult UpdateDistrict(District district)
        {
            try
            {
                _districtDal.Update(district);
                return new SuccessResult(message: Messages.DistrictUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }
    }



}