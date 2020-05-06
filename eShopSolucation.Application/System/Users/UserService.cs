using eShopSolucation.Data.Entities;
using eShopSolucation.Utilities.Exceptions;
using eShopSolucation.ViewModels.Common;
using eShopSolucation.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolucation.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;

        // library to User Entity
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }
        public async Task<ApiResult<string>> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return null; ;

            var result = await _signInManager.PasswordSignInAsync(user, request.PassWord, request.RememnerMe, true);
            if (!result.Succeeded)
            {
                return null;
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, request.UserName)
            };
            // sau khi có claims thì chúng ta sẽ mã hóa claims đấy bằng SymmetricSecurityKey
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
              _config["Tokens:Issuer"],
              claims,
              expires: DateTime.Now.AddHours(3),
              signingCredentials: creds);

            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));


        }

        public async Task<ApiResult<Uservm>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<Uservm>("User không tồn tại");
            }
            var userVm = new Uservm()
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                Dob = user.Dob,
                Id = user.Id,
                LastName = user.LastName
            };
            return new ApiSuccessResult<Uservm>(userVm);
        }

        public async Task<ApiResult<PageResult<Uservm>>> GetUserPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users; 
            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(x => x.UserName.Contains(request.KeyWord)
                || x.PhoneNumber.Contains(request.KeyWord));
            }
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new Uservm()
                {
                    Id = x.Id,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    FirstName = x.FirstName
                }).ToListAsync();

            //select and projection
            var pageResult = new PageResult<Uservm>()
            {
                TotalRecord = totalRow,
                Items = data,
            };
            return new ApiSuccessResult<PageResult<Uservm>>(pageResult);
        }
        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var userName = await _userManager.FindByNameAsync(request.UserName);
            if (userName != null)
            {
                return new ApiErrorResult<bool>("Tai khoan đã tồn tại.");
            }
            var email = await _userManager.FindByEmailAsync(request.Email);
            if (email != null)
            {
                return new ApiErrorResult<bool>("Email đã tồn tại.");
            }
            var user = new AppUser()
            {
                Dob = DateTime.Now,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, request.PassWord);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Đăng ký không thành công!");
        }

        public async Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request)
        {
            var email = await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id);
            if (email)
            {
                return new ApiErrorResult<bool>("Email đã tồn tại.");
            }
            var user = await _userManager.FindByIdAsync(id.ToString());
            user.Dob = DateTime.Now;
            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;
   
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Update không thành công!");
        }

        public Task<ApiResult<bool>> Update(UserUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
