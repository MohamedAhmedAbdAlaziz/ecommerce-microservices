﻿using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;

        public BasketController(IBasketRepository repository)
        {
           _repository = repository;
        }
        [HttpGet("{userName}" , Name ="GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
       public async Task<ActionResult<ShoppingCart>> GetBasket(string username)
        {
            var basket= await _repository.GetBasket(username);  
            return Ok(basket?? new ShoppingCart(username));
        }

         [HttpPost]
         [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        { 
        return Ok(await _repository.UpdateBasket(basket));  
        }
        [HttpDelete]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> DeleteBasket(string userName)
        {
            await _repository.Delete(userName);
            return Ok();
        }

    }
}
