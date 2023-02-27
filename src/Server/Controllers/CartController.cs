﻿using System.Security.Claims;
using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Mvc;
using Server.Services.CartService;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpPost("products")]
    public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetCartProducts(List<CartItem> cartItems)
    {
        var result = await _cartService.GetCartProducts(cartItems);
        return Ok(result);
    }

     [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> StoreCartItems(List<CartItem> cartItems)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var result = await _cartService.StoreCartItems(cartItems);
        return Ok(result);
    }

    [HttpGet("count")]
    public async Task<ActionResult<ServiceResponse<int>>> GetCartItemsCounts()
    {
        return await _cartService.GetCartItemsCount();
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetDbCartProducts()
    {
        var result = await _cartService.GetDbCartProducts();
        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<ActionResult<ServiceResponse<bool>>> AddToCart(CartItem cartItem)
    {
        var result = await _cartService.AddToCart(cartItem);
        return Ok(result);
    }
    
    [HttpPut("update-quantity")]
    public async Task<ActionResult<ServiceResponse<bool>>> UpdateQuantity(CartItem cartItem)
    {
        var result = await _cartService.UpdateQuantity(cartItem);
        return Ok(result);
    }

    [HttpDelete("{productId}/{productTypeId}")]
    public async Task<ActionResult<ServiceResponse<bool>>> RemoveItemFromCart(int productId, int productTypeId)
    {
        var result = await _cartService.RemoveItemFromCart(productId, productTypeId);
        return Ok(result);
    }
}
