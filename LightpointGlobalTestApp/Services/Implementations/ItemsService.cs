using AutoMapper;
using LightpointGlobalTestApp.Common;
using LightpointGlobalTestApp.Model;
using LightpointGlobalTestApp.Model.DatabaseModels;
using LightpointGlobalTestApp.SearchModel;
using LightpointGlobalTestApp.Services.Contracts;
using LightpointGlobalTestApp.ViewModels.Item;
using System;
using System.Linq;

namespace LightpointGlobalTestApp.Services.Implementations
{
    public class ItemsService : IItemsService
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IMapper _mapper;
        public ItemsService(ApplicationDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ItemViewModel Create(CreateItemViewModel model)
        {
            var item = _mapper.Map<Item>(model);
            item.CreateAt = DateTime.UtcNow;
            item.LastUpdateAt = DateTime.UtcNow;

            _context.Items.Add(item);

            var shop = GetShopById(item.ShopId);
            shop.LastUpdateAt = DateTime.UtcNow;

            _context.SaveChanges();

            var itemViewModel = _mapper.Map<ItemViewModel>(item);

            return itemViewModel;
        }

        public void Delete(int id)
        {
            var item = GetById(id);

            _context.Items.Remove(item);

            var shop = GetShopById(item.ShopId);
            shop.LastUpdateAt = DateTime.UtcNow;

            _context.SaveChanges();
        }

        public ItemViewModel Get(int id)
        {
            var item = GetById(id);

            var itemViewModel = _mapper.Map<ItemViewModel>(item);

            return itemViewModel;
        }

        public SearchResult<Item> Search(ItemsSearchModel model)
        {
            var query = _context.Items.AsQueryable();

            return model.Find(query);
        }

        public void Update(int id, UpdateItemViewModel model)
        {
            var item = GetById(id);

            item = _mapper.Map(model, item);

            item.LastUpdateAt = DateTime.UtcNow;

            var shop = GetShopById(item.ShopId);
            shop.LastUpdateAt = DateTime.UtcNow;

            _context.Items.Update(item);
            _context.SaveChanges();
        }

        #region Private

        private Item GetById(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            if (item == null) throw new Exception("Item not found.");

            return item;
        }

        private Shop GetShopById(int id)
        {
            var shop = _context.Shops.FirstOrDefault(s => s.Id == id);
            if (shop == null) throw new Exception($"Shop with Id={id} not found");

            return shop;
        }

        #endregion
    }
}