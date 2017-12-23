using Dapper;
using FatDairy.Domain.Models;
using FatDairy.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace SqlRepositories
{
    public class FoodTrackItemRepository : BaseSqlRepository, IFoodTrackItemRepository
    {
        public FoodTrackItemRepository(DbConnection connection) : base(connection)
        {
        }

        public async Task AddAsync(int fattyId, FoodTrackItem item)
        {
            var spName = "public.add_food_track_item";
            var query = await _connection.ExecuteAsync(
                    spName,
                    new {
                        fatty_id = fattyId,
                        images = item.Images,
                        text = item.Text,
                        item.date
                    }
                );

            if (query != 1)
                throw new Exception("Sql error");
        }

        public IEnumerable<FoodTrackItem> Get(int fattyId, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
