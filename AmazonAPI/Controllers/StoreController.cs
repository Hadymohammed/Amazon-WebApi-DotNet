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
    [Authorize]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        //create store
        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody] CreateStoreDTO model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
                if (userId == null)
                {
                    return Unauthorized();
                }
                var store = new Store()
                {
                    Name = model.Name,
                    LogoUrl = model.LogoUrl,
                    Address = model.Address,
                    Phone = model.Phone,
                    Email = model.Email,
                    Description = model.Description,
                    Website = model.Website,
                    OwnerId = userId
                };
                try
                {
                    await _storeService.AddAsync(store);
                    var url = Url.Action("Store", new { id = store.Id });
                    return Created(url, store);
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
        }
        //get store by id
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Store(int id)
        {
            try
            {
                var store = await _storeService.GetByIdAsync(id, s => s.Owner);
                if (store == null)
                {
                    return NotFound();
                }
                return Ok(new StoreDetailsDTO
                {
                    Name = store.Name,
                    LogoUrl = store.LogoUrl,
                    Address = store.Address,
                    Phone = store.Phone,
                    BusinessEmail = store.Email,
                    Description = store.Description,
                    Website = store.Website,
                    OwnerId = store.OwnerId,
                    OwnerName = store.Owner!.FirstName + " " + store.Owner.LastName
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //get all stores
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Stores()
        {
            try
            {
                var stores = await _storeService.GetAllAsync(s => s.Owner);
                if (stores == null)
                {
                    return NotFound();
                }
                return Ok(stores.Select(s => new StoreDetailsDTO
                {
                    Name = s.Name,
                    LogoUrl = s.LogoUrl,
                    Address = s.Address,
                    Phone = s.Phone,
                    BusinessEmail = s.Email,
                    Description = s.Description,
                    Website = s.Website,
                    OwnerId = s.OwnerId,
                    OwnerName = s.Owner!.FirstName + " " + s.Owner.LastName
                }));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStore(int id, [FromBody] CreateStoreDTO model)
        {
            if (ModelState.IsValid)
            {
                var store = await _storeService.GetByIdAsync(id, s => s.Owner);
                if (store == null)
                {
                    return NotFound();
                }
                if (store.OwnerId != User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value)
                {
                    return Unauthorized();
                }
                store.Name = model.Name;
                store.LogoUrl = model.LogoUrl;
                store.Address = model.Address;
                store.Phone = model.Phone;
                store.Email = model.Email;
                store.Description = model.Description;
                store.Website = model.Website;
                try
                {
                    await _storeService.UpdateAsync(store.Id, store);
                    return Ok(new StoreDetailsDTO
                    {
                        Name = store.Name,
                        LogoUrl = store.LogoUrl,
                        Address = store.Address,
                        Phone = store.Phone,
                        BusinessEmail = store.Email,
                        Description = store.Description,
                        Website = store.Website,
                        OwnerId = store.OwnerId,
                        OwnerName = store.Owner!.FirstName + " " + store.Owner.LastName
                    });
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
        }
    }
}