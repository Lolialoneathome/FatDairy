using FatDairy.Domain.Repos;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data.Common;

namespace SqlRepositories.IoC
{
    public static class MsIoC
    {
        public static void AddSqlRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<DbConnection>(
                provider => {
                    var res = new NpgsqlConnection(connectionString);
                    res.Open();
                    return res;
                }
            );

            services.AddScoped<IFattyRepository, FattyRepository>();
            services.AddScoped<IFoodTrackItemRepository, FoodTrackItemRepository>();
        }
    }
}
