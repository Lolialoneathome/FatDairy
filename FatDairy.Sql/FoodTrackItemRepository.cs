using Dapper;
using FatDairy.Domain;
using FatDairy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace FatDairy.Sql
{
    public class FoodTrackItemRepository : IFoodTrackItemRepository
    {
        protected readonly DbConnection _connection;
        public FoodTrackItemRepository(DbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
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
                        date = item.date
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
