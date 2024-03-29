﻿using Bussiness.Abstract;
using Bussiness.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getAll")]
        public IActionResult Get()
        {
            var result = _productService.GetAll();
            if (result.Succes)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet]
        public IActionResult Get(int id) {
            var result = _productService.GetByID(id);

            if (result.Succes)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var resullt = _productService.Add(product);
            if (resullt.Succes) {
                return Ok(resullt.Message);
            }
            return BadRequest(resullt.Message);
        }
    }
}
