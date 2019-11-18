using LightpointGlobalTestApp.Common;
using LightpointGlobalTestApp.Model.DatabaseModels;
using LightpointGlobalTestApp.SearchModel;
using LightpointGlobalTestApp.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightpointGlobalTestApp.Services.Contracts
{
    public interface IItemsService
    {
        SearchResult<Item> Search(ItemsSearchModel model);
        ItemViewModel Get(int id);
        ItemViewModel Create(CreateItemViewModel model);
        void Update(int id, UpdateItemViewModel model);
        void Delete(int id);
    }
}
