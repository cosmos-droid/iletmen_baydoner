
using iletmenbaydoner.Entities.Concrete;
using iletmenbaydoner.Entities.Utilities;
using IResult = iletmenbaydoner.Entities.Utilities.IResult;

namespace iletmenbaydoner.Business.Abstract
{
    public interface IDistrictService
    {
        IDataResult<District> GetDistrictById(long districtId);
        IDataResult<District> GetDistrictByName(string districtName);

        IDataResult<IList<District>> GetAllDistricts();
        IResult AddDistrict(District district);
        IResult UpdateDistrict(District district);
        IResult DeleteDistrict(District district);

    }
}