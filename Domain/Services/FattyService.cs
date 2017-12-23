using FatDairy.Domain.Models;
using FatDairy.Domain.Repos;
using System;
using System.Threading.Tasks;

namespace FatDairy.Domain.Services
{
    public class FattyService
    {
        protected readonly IFattyRepository _fattyRepository;

        public async Task<Fatty> AddFattyAsync(UserInfo userInfo,
            bool hideFoodTrack,
            bool hideAge,
            bool hideEmail,
            double currentWeigth,
            double desiredWeigth,
            double height,
            int? trainerId = null)
        {
            var maybeExistFatty = _fattyRepository.GetByEmail(userInfo.Email);
            if (maybeExistFatty != null)
                throw new InvalidOperationException("Fatty with this email already exist");

            var newFatty = new Fatty(
                userInfo,
                hideFoodTrack,
                hideAge,
                hideEmail,
                currentWeigth,
                desiredWeigth,
                height,
                null
                );

            await _fattyRepository.AddFatty(newFatty);

            return newFatty;
        }
    }
}
