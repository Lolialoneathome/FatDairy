using FatDairy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FatDairy.Domain.Repos
{
    public interface IFoodTrackItemRepository
    {
        Task AddAsync(int fattyId, FoodTrackItem item);

        IEnumerable<FoodTrackItem> Get(int fattyId, DateTime startDate, DateTime endDate);
    }
}
