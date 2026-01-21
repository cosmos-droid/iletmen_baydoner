namespace iletmenbaydoner.Controllers
{
    using Business.Abstract;
    using Entities.Concrete;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using iletmenbaydoner.Entities.Utilities;
    using iletmenbaydoner.Entites.Concrete;

    [Route("api/[controller]")]
    [ApiController]
    public class OrderHeaderController : ControllerBase
    {
        private readonly IOrderHeaderService _orderHeaderService;

        public OrderHeaderController(IOrderHeaderService orderHeaderService)
        {
            _orderHeaderService = orderHeaderService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(long orderHeaderId)
        {
            var result = _orderHeaderService.GetOrderHeaderById(orderHeaderId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyorderno")]
        public IActionResult GetByOrderNo(string orderNo)
        {
            var result = _orderHeaderService.GetOrderHeaderByOrderNo(orderNo);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }



        [HttpPost(template: "add")]
        public IActionResult Add(OrderHeader orderHeader)
        {
            var result = _orderHeaderService.AddOrderHeader(orderHeader);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "addandgetorderheader")]
        public IActionResult AddAndGetOrderHeader(long branchId, string orderNo, string customerName, string customerAdress)
        {
            var result = _orderHeaderService.AddAndGetOrderHeader(branchId, orderNo, customerName, customerAdress);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpPost(template: "delete")]
        public IActionResult Delete(OrderHeader orderHeader)
        {
            var result = _orderHeaderService.DeleteOrderHeader(orderHeader);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost(template: "update")]
        public IActionResult Update(OrderHeader orderHeader)
        {
            var result = _orderHeaderService.UpdateOrderHeader(orderHeader);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getall")]
        public IActionResult GetAll()
        {
            var result = _orderHeaderService.GetAllOrderHeaders();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


    }
}