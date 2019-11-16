using LightpointGlobalTestApp.Common;
using LightpointGlobalTestApp.Model.DatabaseModels;
using LightpointGlobalTestApp.SearchModel;
using LightpointGlobalTestApp.ViewModels.Shop;

namespace LightpointGlobalTestApp.Services.Contracts
{
    public interface IShopsService
    {
        SearchResult<Shop> Search(ShopsSearchModel model);
        ShopViewModel Get(int id);
        ShopViewModel Create(CreateShopViewModel model);
        void Update(int id, UpdateShopViewModel model);
        void Delete(int id);
    }
}
