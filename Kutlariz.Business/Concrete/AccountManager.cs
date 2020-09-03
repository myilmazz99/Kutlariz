using AutoMapper;
using Kutlariz.Business.Abstract;
using Kutlariz.Business.Aspects.Logging;
using Kutlariz.Business.Utilities.Helpers;
using Kutlariz.Business.Validation.FluentValidation;
using Kutlariz.Core.ActionResult;
using Kutlariz.Core.ActionResult.DataResult;
using Kutlariz.Core.Constants;
using Kutlariz.Core.Entities;
using Kutlariz.Entities.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;  
using System.Threading.Tasks;
 
namespace Kutlariz.Business.Concrete
{
    public class AccountManager : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AccountManager(IMapper mapper, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<DataResult<UserDto>> FindByUsername(string username)
        {
            await _roleManager.CreateAsync(new IdentityRole("admin"));
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return new ErrorDataResult<UserDto>(ResultMessages.UserNotFound);

            return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(user));
        }

        public async Task<DataResult<ApplicationUser>> FindByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new ErrorDataResult<ApplicationUser>(ResultMessages.UserNotFound);

            return new SuccessDataResult<ApplicationUser>(user);
        }

        public async Task<Result> Login(LoginDto dto)
        {
            var validationResult = Validator.Validate(dto, new LoginValidator());
            if (!validationResult.IsSuccess) return validationResult;

            var user = await FindByEmail(dto.Email);
            if (!user.IsSuccess) return new ErrorResult(user.Message);

            var result = await _signInManager.PasswordSignInAsync(user.Data, dto.Password, true, true);
            if (!result.Succeeded) return new ErrorResult(ResultMessages.WrongPassword);
            if (result.IsLockedOut) return new ErrorResult(ResultMessages.LoginLockout);

            return new SuccessResult(ResultMessages.LoginSuccess);
        }

        public async Task<Result> Logout()
        {
            await _signInManager.SignOutAsync();
            return new SuccessResult(ResultMessages.LogoutSuccess);
        }

        public async Task<Result> Register(RegisterDto dto)
        {
            var validation = Validator.Validate(dto, new RegisterValidator());
            if (!validation.IsSuccess) return validation;

            var appUser = _mapper.Map<ApplicationUser>(dto);
            var result = await _userManager.CreateAsync(appUser, dto.Password);
            if (!result.Succeeded)
            {
                TranslateIdentityErrors.Translate(result.Errors);
                return new ErrorResult(result.Errors.Select(i => i.Description));
            }

            if (!await _roleManager.RoleExistsAsync("user"))
            {
                await _roleManager.CreateAsync(new IdentityRole("user"));
            }

            await _userManager.AddToRoleAsync(appUser, "user");

            return new SuccessResult(ResultMessages.RegisterSuccess);
        }

        public DataResult<string> GetUserId(ClaimsPrincipal claims)
        {
            var userId = _userManager.GetUserId(claims);
            return new SuccessDataResult<string>(userId);
        }
    }
}
