﻿using AutoMapper;
using HotelListing.Data;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        public AccountController(UserManager<ApiUser>userManager, ILogger<AccountController>logger,
            IMapper mapper)
        {
            _userManager= userManager;
            _logger= logger;
            _mapper= mapper;

        }
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody]UserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attempt for{userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user=_mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.Email;
                var result=await _userManager.CreateAsync(user,userDTO.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code,error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(user,userDTO.Roles);
                return Accepted();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex,$"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something Went Wrong in the {nameof(Register)}",statusCode:500);
            }
        }
        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> LogIn([FromBody] LogInDTO userDTO)
    //    {
    //        _logger.LogInformation($"LogIn Attempt for{userDTO.Email}");
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }
    //        try
    //        {
    //            var result = await _singInManager.PasswordSignInAsync(userDTO.Email,userDTO.Password,
    //                false,false);
    //            if (!result.Succeeded)
    //            {
    //                return Unauthorized(userDTO);
    //            }
    //            return Accepted();
    //        }
    //        catch (Exception ex)
    //        {

    //            _logger.LogError(ex, $"Something Went Wrong in the {nameof(LogIn)}");
    //            return Problem($"Something Went Wrong in the {nameof(LogIn)}", statusCode: 500);
    //        }
    //    }

    }
}
