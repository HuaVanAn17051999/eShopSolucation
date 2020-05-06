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
        Task<ApiResult<string>> Authencate(LoginRequest request);
        Task<ApiResult<bool>> Register(RegisterRequest request);
        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);
        Task<ApiResult<PageResult<Uservm>>> GetUserPaging(GetUserPagingRequest request);
        Task<ApiResult<Uservm>> GetById(Guid id);

    }
}
