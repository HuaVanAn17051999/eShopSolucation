using eShopSolucation.ViewModels.Common;
using eShopSolucation.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolucation.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PageResult<Uservm>> GetUserPagings(GetUserPagingRequest request);
        Task<bool> RegisterUser(RegisterRequest registerRequest);
    }
}
