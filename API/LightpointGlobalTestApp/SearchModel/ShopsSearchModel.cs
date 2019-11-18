using LightpointGlobalTestApp.Common;
using LightpointGlobalTestApp.Model.DatabaseModels;
using System;
using System.Linq;

namespace LightpointGlobalTestApp.SearchModel
{
    public class ShopsSearchModel : OrderedSearchModel<Shop>
    {
        public int[] Ids { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        protected override IQueryable<Shop> Ordering(IQueryable<Shop> query)
        {
            switch (Predicate)
            {
                default:
                    return Order(query, x => x.Id);
            }
        }

        public override IQueryable<Shop> Filter(IQueryable<Shop> query)
        {
            if (Ids != null && Ids.Length > 0) query = query.Where(x => Ids.Contains(x.Id));
            if (!string.IsNullOrEmpty(Name)) query = query.Where(x => x.Name.ToUpper().Contains(Name.ToUpper()));
            if (!string.IsNullOrEmpty(Address)) query = query.Where(x => x.Address.ToUpper().Contains(Address.ToUpper()));
            return base.Filter(query);
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
