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
        var result = await _cartService.StoreCartItems(cartItems, userId);
        return Ok(result);
    }
}
