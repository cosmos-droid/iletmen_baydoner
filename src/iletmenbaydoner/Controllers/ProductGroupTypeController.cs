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
    public class ProductGroupTypeController : ControllerBase
    {
        private readonly IProductGroupTypeService _productGroupTypeService;

        public ProductGroupTypeController(IProductGroupTypeService productGroupTypeService)
        {
            _productGroupTypeService = productGroupTypeService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(long productGroupTypeId)
        {
            var result = _productGroupTypeService.GetProductGroupTypeById(productGroupTypeId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getproductgoruptypesbyproductgroupid")]
        public IActionResult GetProductGroupTypesByProductGroupId(long productGroupId)
        {
            var result = _productGroupTypeService.GetProductGroupTypesByProductGroupId(productGroupId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }



        [HttpPost(template: "add")]
        public IActionResult Add(ProductGroupType productGroupType)
        {
            var result = _productGroupTypeService.AddProductGroupType(productGroupType);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "delete")]
        public IActionResult Delete(ProductGroupType productGroupType)
        {
            var result = _productGroupTypeService.DeleteProductGroupType(productGroupType);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost(template: "update")]
        public IActionResult Update(ProductGroupType productGroupType)
        {
            var result = _productGroupTypeService.UpdateProductGroupType(productGroupType);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getall")]
        public IActionResult GetAll()
        {
            var result = _productGroupTypeService.GetAllProductGroupTypes();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


    }
}