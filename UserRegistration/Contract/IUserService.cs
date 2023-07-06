
using UserRegistration.Models;
using UserRegistration.ViewModel;

namespace UserRegistration.Contract
{
    public interface IUserService
    {
        Task<List<User>> GetUserList();
        Task<User> GetUserDetailsById(int userId);
        Task<ResponseModel> SaveUser(UserViewModel user);
        Task<ResponseModel> DeleteUser(int userId);
    }
}
