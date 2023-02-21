﻿using BlazorEcommerce.Shared;

namespace Server.Services.CartService;

public interface ICartService
{
    Task<ServiceResponse<List<CartProductResponse>>> GetCartProducts(List<CartItem> cartItems);
    Task<ServiceResponse<List<CartProductResponse>>> StoreCartItems(List<CartItem> cartItems);

}
