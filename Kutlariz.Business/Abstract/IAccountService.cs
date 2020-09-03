using Kutlariz.Core.ActionResult;
using Kutlariz.Core.ActionResult.DataResult;
using Kutlariz.Core.Entities;
using Kutlariz.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kutlariz.Business.Abstract
{
    public interface IAccountService
    {
        Task<Result> Login(LoginDto dto);
        Task<Result> Register(RegisterDto dto);
        Task<Result> Logout();
        Task<DataResult<UserDto>> FindByUsername(string username);
        Task<DataResult<ApplicationUser>> FindByEmail(string email);
        DataResult<string> GetUserId(ClaimsPrincipal claims);
    }
}
