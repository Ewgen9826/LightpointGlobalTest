using System.Linq;

namespace LightpointGlobalTestApp.Common
{
    public class SearchResult<TEntity>
    {
        public IQueryable<TEntity> Body { get; set; }
        public int Count { get; set; }
    }
}
