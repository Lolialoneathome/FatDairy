using FatDairy.Domain.Models;
using FatDairy.Domain.Repos;
using System;
using System.Threading.Tasks;

namespace FatDairy.Domain.Services
{
    public class FoodTrackService
    {
        protected readonly IFoodTrackItemRepository _repository;

        public FoodTrackService(IFoodTrackItemRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task Add(int fattyId, FoodTrackItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (fattyId == 0)
                throw new Exception("Somethink wrong, ask Katya why");

            await _repository.AddAsync(fattyId, item);
        }
    }
}
