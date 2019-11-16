using Microsoft.EntityFrameworkCore;

namespace LightpointGlobalTestApp.Model
{
    public class ApplicationDatabaseContext: DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
        {

        }
    }
}
