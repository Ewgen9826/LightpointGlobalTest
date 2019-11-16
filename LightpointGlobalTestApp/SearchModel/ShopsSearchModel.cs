using LightpointGlobalTestApp.Common;
using LightpointGlobalTestApp.Model.DatabaseModels;
using System;
using System.Linq;

namespace LightpointGlobalTestApp.SearchModel
{
    public class ShopsSearchModel : OrderedSearchModel<Shop>
    {
        protected override IQueryable<Shop> Ordering(IQueryable<Shop> query)
        {
            switch (Predicate)
            {
                default:
                    return Order(query, x => x.Id);
            }
        }

        public SearchResult<Shop> Find(IQueryable<Shop> query)
        {
            var view = Filter(query);
            return new SearchResult<Shop>
            {
                Body = Ordering(view).Skip(Skip).Take(Take),
                Count = view.Count()
            };
        }
    }
}
