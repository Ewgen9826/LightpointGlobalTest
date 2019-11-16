using AutoMapper;
using LightpointGlobalTestApp.Model.DatabaseModels;
using LightpointGlobalTestApp.ViewModels.Shop;

namespace LightpointGlobalTestApp.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // view=>shop
            CreateMap<CreateShopViewModel, Shop>();
            CreateMap<UpdateShopViewModel, Shop>();
            // shop=>view
            CreateMap<Shop, ShopViewModel>();
        }
    }
}
