using AutoMapper;
using LightpointGlobalTestApp.Common;
using LightpointGlobalTestApp.Model;
using LightpointGlobalTestApp.Model.DatabaseModels;
using LightpointGlobalTestApp.SearchModel;
using LightpointGlobalTestApp.Services.Contracts;
using LightpointGlobalTestApp.ViewModels.Shop;
using System;
using System.Linq;

namespace LightpointGlobalTestApp.Services.Implementations
{
    public class ShopsService : IShopsService
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IMapper _mapper;

        public ShopsService(ApplicationDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ShopViewModel Get(int id)
        {
            var shop = GetById(id);

            var shopViewModel = _mapper.Map<ShopViewModel>(shop);

            return shopViewModel;
        }

        public SearchResult<Shop> Search(ShopsSearchModel model)
        {
            var query = _context.Shops.AsQueryable();

            var shops = model.Find(query);

            return shops;
        }

        public ShopViewModel Create(CreateShopViewModel model)
        {
            var shop = _mapper.Map<Shop>(model);
            shop.CreateAt = DateTime.UtcNow;
            shop.LastUpdateAt = DateTime.UtcNow;

;           _context.Shops.Add(shop);
            _context.SaveChanges();

            var shopViewModel = _mapper.Map<ShopViewModel>(shop);

            return shopViewModel;
        }

        public void Delete(int id)
        {
            var shop = GetById(id);

            _context.Shops.Remove(shop);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateShopViewModel model)
        {
            var shop = GetById(id);

            shop = _mapper.Map(model, shop);

            shop.LastUpdateAt = DateTime.UtcNow;

            _context.Update(shop);
            _context.SaveChanges();
        }

        #region Private

        private Shop GetById(int id)
        {
            var shop = _context.Shops.FirstOrDefault(s => s.Id == id);
            if (shop == null) throw new Exception("Shop not found.");

            return shop;
        }

        #endregion
    }
}
