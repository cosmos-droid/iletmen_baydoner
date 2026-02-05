namespace iletmenbaydoner.Controllers
{
    using Business.Abstract;
    using Entities.Concrete;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using iletmenbaydoner.Entities.Utilities;

    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(long districtId)
        {
            var result = _districtService.GetDistrictById(districtId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyname")]
        public IActionResult GetByName(string districtName)
        {
            var result = _districtService.GetDistrictByName(districtName);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpPost(template: "add")]
        public IActionResult Add(District district)
        {
            var result = _districtService.AddDistrict(district);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "delete")]
        public IActionResult Delete(District district)
        {
            var result = _districtService.DeleteDistrict(district);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost(template: "update")]
        public IActionResult Update(District district)
        {
            var result = _districtService.UpdateDistrict(district);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getall")]
        public IActionResult GetAll()
        {
            var result = _districtService.GetAllDistricts();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


    }
}