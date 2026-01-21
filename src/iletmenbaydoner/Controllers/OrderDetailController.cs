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
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(long orderDetailId)
        {
            var result = _orderDetailService.GetOrderDetailById(orderDetailId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "add")]
        public IActionResult Add(OrderDetail orderDetail)
        {
            var result = _orderDetailService.AddOrderDetail(orderDetail);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "delete")]
        public IActionResult Delete(OrderDetail orderDetail)
        {
            var result = _orderDetailService.DeleteOrderDetail(orderDetail);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost(template: "update")]
        public IActionResult Update(OrderDetail orderDetail)
        {
            var result = _orderDetailService.UpdateOrderDetail(orderDetail);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getall")]
        public IActionResult GetAll()
        {
            var result = _orderDetailService.GetAllOrderDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


    }
}