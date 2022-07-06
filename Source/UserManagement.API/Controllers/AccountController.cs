﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary;
using UserManagement.API.Enums;
using UserManagement.API.Models;
using UserManagement.API.Models.Data;
using UserManagement.API.Models.Repository;

namespace UserManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository) => _accountRepository = accountRepository;

        [HttpPost("create-account")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Result<Account>),  StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAccount([FromBody] AccountRequest request)
        {
            var result = await _accountRepository.CreateAsync(new Account
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                RoleId = request.RoleId,
                PhoneNumber = request.PhoneNumber,
                Status =  Status.Disabled,
                DateCreated = DateTime.Now
            });

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _accountRepository.GetAllAsync());

        [HttpGet("sign-up/resend-otp/{email}")]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ResendOtp(string email)
        {
            var result = await _accountRepository.ResendOtpAsync(email);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(Result<Account>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<Account>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _accountRepository.LoginAsync(request);

            if (!result.Success)
                return StatusCode(StatusCodes.Status403Forbidden, result);
            
            return Ok(result);
        }

        [HttpPost("complete-sign-up")]
        public async Task<IActionResult> ConfirmAccount(CompleteSignUpRequest request)
        {
            var result = await _accountRepository.CompleteSignUpAsync(request);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("change-password")]
        [Authorize]
        [ProducesResponseType(typeof(Result<Account>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<Account>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            var result = await _accountRepository.ChangePasswordAsync(request);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("reset-password/verification-code/{email}")]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(Result<string>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPassword(string email)
        {
            var result = await _accountRepository.GetResetPasswordCodeAsync(email);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("reset-password")]
        [ProducesResponseType(typeof(Result<Account>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<Account>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            var result = await _accountRepository.ResetPasswordAsync(request);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}