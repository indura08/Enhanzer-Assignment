using BookMate.Data_Models;
using BookMate.Services_Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookMate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager, IUser userService)
        {
            _userManager = userManager;
            _userService = userService;
        }


        //these functionalities are not included in the assignment pdf
        //im just adding this functionality demonstrate that if we want to create role based access to each end points in book control, we have to create user accounts and just use jwt authntication to authenticate users to keep up the security
        //extending IdentityUser class will help to manage role based access, pasword hashing and other security stuff too
        // i didnt implement the jwt authentication part and role based access since it hasnt mentioned in the assignment requirement pdf


        [HttpPost("create")]
        public async Task<IActionResult> CreateNewuser([FromBody] UserDto userdto)
        {
            if (userdto != null)
            {
                await _userService.AddNewUser(userdto);
                return Ok();
            }
            else
            {
                return BadRequest("User dto not complete");
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteById(string id)
        {
            await _userService.DeleteUser(id);
            return Ok("Deleted");
        
        }
    
    }
}
