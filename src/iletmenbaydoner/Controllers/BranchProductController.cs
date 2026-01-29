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
    public class BranchProductController : ControllerBase
    {
        private readonly IBranchProductService _branchProductService;

        public BranchProductController(IBranchProductService branchProductService)
        {
            _branchProductService = branchProductService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(long branchProductId)
        {
            var result = _branchProductService.GetBranchProductById(branchProductId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "add")]
        public IActionResult Add(BranchProduct branchProduct)
        {
            var result = _branchProductService.AddBranchProduct(branchProduct);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "delete")]
        public IActionResult Delete(BranchProduct branchProduct)
        {
            var result = _branchProductService.DeleteBranchProduct(branchProduct);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost(template: "update")]
        public IActionResult Update(BranchProduct branchProduct)
        {
            var result = _branchProductService.UpdateBranchProduct(branchProduct);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "updatebranchproductstockquantity")]
        public IActionResult UpdateBranchProductStockQuantity(long branchProductId, int stockQuantity, string orderNo)
        {
            var result = _branchProductService.UpdateBranchProductStockQuantity(branchProductId, stockQuantity, orderNo);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getall")]
        public IActionResult GetAll()
        {
            var result = _branchProductService.GetAllBranchProducts();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getbranchproductsbybranchid")]
        public IActionResult GetBranchProductsByBranchId(long branchId)
        {
            var result = _branchProductService.GetBranchProductsByBranchId(branchId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }



    }
}