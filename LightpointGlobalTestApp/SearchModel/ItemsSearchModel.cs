using LightpointGlobalTestApp.Common;
using LightpointGlobalTestApp.Model.DatabaseModels;
using System.Linq;

namespace LightpointGlobalTestApp.SearchModel
{
    public class ItemsSearchModel : OrderedSearchModel<Item>
    {
        public int[] Ids { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? ShopId { get; set; }

        protected override IQueryable<Item> Ordering(IQueryable<Item> query)
        {
            switch (Predicate)
            {
                default:
                    return Order(query, x => x.Id);
            }
        }

        public override IQueryable<Item> Filter(IQueryable<Item> query)
        {
            if (Ids != null && Ids.Length > 0) query = query.Where(x => Ids.Contains(x.Id));
            if (!string.IsNullOrEmpty(Name)) query = query.Where(x => x.Name.ToUpper().Contains(Name.ToUpper()));
            if(!string.IsNullOrEmpty(Description)) query=query.Where(x=>x.Description.ToUpper().Contains(Description.ToUpper()));
            if (ShopId.HasValue) query = query.Where(x => x.ShopId == ShopId); 
            return base.Filter(query);
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
