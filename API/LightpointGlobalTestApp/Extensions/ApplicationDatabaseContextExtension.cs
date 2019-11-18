using LightpointGlobalTestApp.Model;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightpointGlobalTestApp.Extensions
{
    public static class ApplicationDatabaseContextExtension
    {
        public static bool AllMigrationsApplied(this ApplicationDatabaseContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void Started(this ApplicationDatabaseContext context)
        {
           
        }
    }
}
