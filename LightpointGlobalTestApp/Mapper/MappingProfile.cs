using AutoMapper;
using LightpointGlobalTestApp.Model.DatabaseModels;
using LightpointGlobalTestApp.ViewModels.Item;
using LightpointGlobalTestApp.ViewModels.Shop;

namespace LightpointGlobalTestApp.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //  view=>shop
            CreateMap<CreateShopViewModel, Shop>();
            CreateMap<UpdateShopViewModel, Shop>();
            //  shop=>view
            CreateMap<Shop, ShopViewModel>();

            //  view=>item
            CreateMap<CreateItemViewModel, Item>();
            CreateMap<UpdateItemViewModel, Item>();
            //  item=>view
            CreateMap<Item, ItemViewModel>();
        }
    }
}
