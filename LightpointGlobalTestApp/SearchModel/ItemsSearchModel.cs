using LightpointGlobalTestApp.Common;
using LightpointGlobalTestApp.Model.DatabaseModels;
using System.Linq;

namespace LightpointGlobalTestApp.SearchModel
{
    public class ItemsSearchModel : OrderedSearchModel<Item>
    {
        protected override IQueryable<Item> Ordering(IQueryable<Item> query)
        {
            switch (Predicate)
            {
                default:
                    return Order(query, x => x.Id);
            }
        }

        public SearchResult<Item> Find(IQueryable<Item> query)
        {
            var view = Filter(query);
            return new SearchResult<Item>
            {
                Body = Ordering(view).Skip(Skip).Take(Take),
                Count = view.Count()
            };
        }
    }
}
