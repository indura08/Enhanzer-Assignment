using BookMate.Data_Models;
using System.Threading.Tasks;

namespace BookMate.Services_Interfaces
{
    public interface IUser 
    {
        Task<string> AddNewUser(UserDto userdto);
        Task DeleteUser(string id);
    }
}
