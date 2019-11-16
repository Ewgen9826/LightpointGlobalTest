using LightpointGlobalTestApp.Model.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace LightpointGlobalTestApp.Model
{
    public class ApplicationDatabaseContext: DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) 
            : base(options)
        {

        }

        public DbSet<Shop> Shops { get; set; }
    }
}
