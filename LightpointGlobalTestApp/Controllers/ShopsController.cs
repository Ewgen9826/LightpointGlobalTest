using AutoMapper;
using LightpointGlobalTestApp.SearchModel;
using LightpointGlobalTestApp.Services.Contracts;
using LightpointGlobalTestApp.ViewModels.Shop;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LightpointGlobalTestApp.Controllers
{
    [Route("api/shops")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IShopsService _shopsService;
        private readonly IMapper _mapper;

        public ShopsController(IShopsService shopsService, IMapper mapper)
        {
            _shopsService = shopsService;
            _mapper = mapper;
        }

        //  GET: api/shops
        [HttpGet]
        public IActionResult Search([FromQuery] ShopsSearchModel model)
        {
            var result = _shopsService.Search(model);

            return Ok(new
            {
                Count = result.Count,
                Body = _mapper.Map<List<ShopViewModel>>(result.Body)
            });
        }

        //  GET: api/shops/1
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            var shop = _shopsService.Get(id);
            return Ok(shop);
        }

        //  POST: api/shops
        [HttpPost]
        public IActionResult Create([FromBody] CreateShopViewModel model)
        {
            var shop = _shopsService.Create(model);
            return Ok(shop);
        }

        //  PUT: api/shops/1
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateShopViewModel model)
        {
            _shopsService.Update(id, model);
            return Ok();
        }

        //  DELETE: api/shops/1
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _shopsService.Delete(id);
            return Ok();
        }
    }
}