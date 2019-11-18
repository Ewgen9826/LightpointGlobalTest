using System.Collections.Generic;
using AutoMapper;
using LightpointGlobalTestApp.SearchModel;
using LightpointGlobalTestApp.Services.Contracts;
using LightpointGlobalTestApp.ViewModels.Item;
using Microsoft.AspNetCore.Mvc;

namespace LightpointGlobalTestApp.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService _itemsService;
        private readonly IMapper _mapper;

        public ItemsController(IItemsService itemsService, IMapper mapper)
        {
            _itemsService = itemsService;
            _mapper = mapper;
        }
        //  GET: api/items
        [HttpGet]
        public IActionResult Search([FromQuery] ItemsSearchModel model)
        {
            var result = _itemsService.Search(model);

            return Ok(new
            {
                Count = result.Count,
                Body = _mapper.Map<List<ItemViewModel>>(result.Body)
            });
        }

        //  GET: api/items/1
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            var shop = _itemsService.Get(id);
            return Ok(shop);
        }

        //  POST: api/items
        [HttpPost]
        public IActionResult Create([FromBody] CreateItemViewModel model)
        {
            var shop = _itemsService.Create(model);
            return Ok(shop);
        }

        //  PUT: api/items/1
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateItemViewModel model)
        {
            _itemsService.Update(id, model);
            return Ok();
        }

        //  DELETE: api/items/1
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _itemsService.Delete(id);
            return Ok();
        }

    }
}