using FatDairy.Domain.Models;
using FatDairy.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApi.Auth;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FoodTrackController : Controller
    {
        protected readonly IAppUser _appUser;
        protected readonly FoodTrackService _foodTrackService;
        public FoodTrackController(FoodTrackService foodTrackService, IAppUser appUser)
        {
            _foodTrackService = foodTrackService ?? throw new ArgumentNullException(nameof(foodTrackService));
            _appUser = appUser;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]FoodTrackItem item)
        {
            try
            {
                if (_appUser == null || _appUser.Id == 0)
                    return BadRequest("For add food track need LOG IN");

                await _foodTrackService.Add(_appUser.Id, item);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception err)
            {

            }
            return StatusCode(StatusCodes.Status500InternalServerError);

        }
    }
}
