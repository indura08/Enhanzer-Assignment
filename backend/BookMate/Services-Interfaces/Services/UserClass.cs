using BookMate.Data_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookMate.Services_Interfaces.Services
{
    public class UserClass : IUser
    {
        private readonly AppDBContext _dbContext;
        private readonly UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserClass(AppDBContext dbContext, UserManager<User> userManager , RoleManager<IdentityRole> rolemanager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = rolemanager;
        }

        public async Task<string> AddNewUser(UserDto userdto)
        {
            if (userdto is null)
            {
                return "Detials are incomplete";
            }

            var newUser = new User()
            {
                UserName = userdto.UserName,
                Email = userdto.Email,
                City = userdto.City,
                Phone = userdto.Phone,
                PasswordHash = userdto.Password,
                Role = userdto.Role,

            };

            var existingUser = await _userManager.FindByEmailAsync(userdto.Email);
            if (existingUser is not null)
            {
                return "User exists";
            }

            var createdUser = await _userManager.CreateAsync(newUser!, userdto.Password);

            if (!createdUser.Succeeded)
            {
                var errors = string.Join(", ", createdUser.Errors.Select(e => e.Description));
                return "Error";
            }

            var checkDonorRole = await _roleManager.FindByNameAsync("User");

            if (newUser.Role == "User" && checkDonorRole is null)
            {
                await _roleManager.CreateAsync(new IdentityRole() { Name = "User" });
                await _userManager.AddToRoleAsync(newUser, "User");
                return "Account created";
            }
            else if (newUser.Role == "User" && checkDonorRole is not null)
            {
                await _userManager.AddToRoleAsync(newUser, "User");
                return "Account created";
            }
            else
            {
                return "Error occured";
            }
        }

        public async Task DeleteUser(string id)
        {
            await _dbContext.Users.Where(user => user.Id == id).ExecuteDeleteAsync();
            
        }


    }
}
