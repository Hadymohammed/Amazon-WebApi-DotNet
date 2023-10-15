using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Data.DTOs;
using AmazonAPI.Data.Consts;
using AmazonAPI.Data.Repository.Services;
using AmazonAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AmazonAPI.Data.Structures;

namespace AmazonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        #region Depndencies
        private readonly IProductService _productService;
        private readonly IStoreService _storeService;
        private readonly IProductTagService _productTagService;
        private readonly IProductPhotoService _productPhotoService;

        public ProductsController(IProductService productService,
            IStoreService storeService,
            IProductTagService productTagService,
            IProductPhotoService productPhotoService)
        {
            _productService = productService;
            _storeService = storeService;
            _productTagService = productTagService;
            _productPhotoService = productPhotoService;
        }
        #endregion
        [HttpPost]
        [Authorize(Roles = UserRoles.Seller)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO model)
        {
            if (ModelState.IsValid)
            {
                var store = await _storeService.GetByIdAsync(model.StoreId);
                if (store!.OwnerId != User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)!.Value)
                {
                    return Unauthorized();
                }
                var product = new Product()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    StoreId = model.StoreId
                };
                try
                {
                    await _productService.AddAsync(product);
                    //add tags
                    if (model.Tags != null)
                    {
                        foreach (var tag in model.Tags)
                        {
                            await _productTagService.AddAsync(new ProductTag()
                            {
                                ProductId = product.Id,
                                Key = tag.Key,
                                Value = tag.Value
                            });
                        }
                    }
                    //add photos
                    if (model.Photos != null)
                    {
                        foreach (var photo in model.Photos)
                        {
                            await _productPhotoService.AddAsync(new ProductPhoto()
                            {
                                ProductId = product.Id,
                                Url = photo.Url,
                                Title = photo.Title
                            });
                        }
                    }
                    var url = Url.Action("GetById", new { id = product.Id });
                    return Created(url, new ProductDetailsDTO()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        Rating = product.Rating,
                        StoreId = product.StoreId,
                        OfferId = product.OfferId,
                        Photos = product.Photos?.Select(p => new PhotoStruct { Id = p.Id, Url = p.Url, Title = p.Title }).ToList(),
                        Tags = product.Tags?.Select(t => new TagStruct { Id = t.Id, Key = t.Key, Value = t.Value }).ToList()
                    });
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _productService.GetAllAsync(p => p.Store, p => p.Photos, p => p.Tags);
                return Ok(products.Select(p => new ProductDetailsDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Rating = p.Rating,
                    StoreId = p.StoreId,
                    OfferId = p.OfferId,
                    Photos = p.Photos?.Select(p => new PhotoStruct { Id = p.Id, Url = p.Url, Title = p.Title }).ToList(),
                    Tags = p.Tags?.Select(t => new TagStruct { Id = t.Id, Key = t.Key, Value = t.Value }).ToList()
                }));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id, p => p.Store, p => p.Photos, p => p.Tags);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(new ProductDetailsDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Rating = product.Rating,
                    StoreId = product.StoreId,
                    OfferId = product.OfferId,
                    Photos = product.Photos?.Select(p => new PhotoStruct { Id = p.Id, Url = p.Url, Title = p.Title }).ToList(),
                    Tags = product.Tags?.Select(t => new TagStruct { Id = t.Id, Key = t.Key, Value = t.Value }).ToList()
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /*[HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Seller)]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] CreateProductDTO model)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.GetByIdAsync(id, product => product.Store);
                if (product == null)
                {
                    return NotFound();
                }
                if (product.Store!.OwnerId != User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)!.Value)
                {
                    return Unauthorized();
                }
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.Quantity = model.Quantity;
                try
                {
                    await _productService.UpdateAsync(product.Id, product);
                    return Ok(product);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }.*/
    }
}