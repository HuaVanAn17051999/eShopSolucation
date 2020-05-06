using eShopSolucation.ViewModels.Common;
using eShopSolucation.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolucation.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
        Task<PageResult<Uservm>> GetUserPaging(GetUserPagingRequest request);

    }
}
