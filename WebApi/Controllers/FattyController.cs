using FatDairy.Domain.Models;
using FatDairy.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FattyController : Controller
    {
        protected readonly FattyService _fattyService;
        public FattyController(FattyService fattyService)
        {
            _fattyService = fattyService ?? throw new ArgumentNullException(nameof(fattyService));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterFattyAsync([FromBody] NewFattyDTO dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest();
                var dtoErrors = ValidateNewFattyDTO(dto);
                if (dtoErrors.Count > 0)
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, dtoErrors);

                var userInfo = new UserInfo(dto.name, dto.surname, dto.password, dto.email, dto.birthday, (Sex)dto.sex);
                var newFatty = await _fattyService.AddFattyAsync
                    (userInfo, dto.hideFoodTrack, dto.hideAge, dto.hideEmail, dto.currentWeight, dto.desireWeight, dto.height);
                return StatusCode(StatusCodes.Status201Created, newFatty);
            }
            catch (Exception err)
            {
                //Maybe here will been logging
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        private List<string> ValidateNewFattyDTO(NewFattyDTO dto)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(dto.name))
                result.Add("Empty Name");
            if (string.IsNullOrEmpty(dto.surname))
                result.Add("Empty Surname");
            if (string.IsNullOrEmpty(dto.password))
                result.Add("Password not set");
            if (string.IsNullOrEmpty(dto.email))
                result.Add("Email not set");

            return result;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFattyAsync(int id) {
            try
            {
                var fatty = Request.HttpContext.Items["CurrentUser"];

                return Ok(fatty);
            }
            catch (Exception err)
            {

            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
