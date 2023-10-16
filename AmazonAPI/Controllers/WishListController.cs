using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AmazonAPI.Data.DTOs;
using AmazonAPI.Data.Repository.Services;
using AmazonAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Customer")]
    public class WishListController : ControllerBase
    {
        private readonly IWishListItemService _wishListItemService;

        public WishListController(IWishListItemService wishListItemService)
        {
            _wishListItemService = wishListItemService;
        }

        [HttpGet]
        [Route("{userId}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetWishLisItemsIdstByUserId(string userId)
        {
            if (userId != User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value)
            {
                return Unauthorized();
            }
            var wishListItems = await _wishListItemService.GetWishListByUserIdAsync(userId);
            return Ok(wishListItems.Select(w => new { Id = w.Id, ProductId = w.ProductId }).ToList());
        }
        [HttpPost]
        [Route("{userId}/{productId}")]
        public async Task<IActionResult> AddProductToWishList(string userId, int productId)
        {
            if (userId != User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value)
            {
                return Unauthorized();
            }
            if (await _wishListItemService.GetByProductIdAsync(productId) != null)
            {
                return BadRequest("Product already exists in wish list");
            }
            var wishListItem = new WishListItem()
            {
                CustomerId = userId,
                ProductId = productId
            };
            await _wishListItemService.AddAsync(wishListItem);
            return Ok(new
            {
                Id = wishListItem.Id,
                CustomerId = wishListItem.CustomerId,
                ProductId = wishListItem.ProductId
            });
        }
        [HttpDelete]
        [Route("{ItemId}")]
        public async Task<IActionResult> DeleteProductFromWishList(int ItemId)
        {
            var wishListItem = await _wishListItemService.GetByIdAsync(ItemId);
            if (wishListItem.CustomerId != User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value)
            {
                return Unauthorized();
            }
            if (wishListItem == null)
            {
                return NotFound();
            }
            await _wishListItemService.DeleteAsync(wishListItem.Id);
            return Ok();
        }
    }
}