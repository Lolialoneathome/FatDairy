using FatDairy.Domain.Models;
using FatDairy.Domain.Repos;
using System;

namespace FatDairy.Domain.Services
{
    public class FoodTrackService
    {
        protected readonly IFoodTrackItemRepository _repository;

        public void Add(Fatty fatty, FoodTrackItem item)
        {
            if (fatty == null)
                throw new ArgumentNullException(nameof(fatty));

            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (fatty.Id == 0)
                throw new Exception("Somethink wrong, ask Katya why");

            _repository.AddAsync(fatty.Id, item);
        }
    }
}
