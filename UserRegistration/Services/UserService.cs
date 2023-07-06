using System;
using UserRegistration.Contract;
using UserRegistration.Models;
using UserRegistration.ViewModel;

namespace UserRegistration.Services
{
    public class UserService : IUserService
    {
        #region Variables And Constructor
        private readonly UserContext _context;
        
        public UserService(UserContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<List<User>> GetUserList()
        {
            List<User> userList;
            try
            {
                userList =  _context.Set<User>().ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return userList;
        }

        public async Task<User> GetUserDetailsById(int userId)
        {
            User user;
            try
            {
                user = _context.Find<User>(userId);
            }
            catch (Exception ex)
            {
                throw;
            }
            return user;
        }

        public async Task<ResponseModel> SaveUser(UserViewModel user)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                User _temp = await GetUserDetailsById(user.UserId);
                if (_temp != null)
                {
                    _temp.Name = user.Name;
                    _temp.Email = user.Email;
                    _temp.Password = user.Password;
                    _context.Update(_temp);
                    model.Messsage = "User Update Successfully";
                }
                else
                {
                    _temp.Name = user.Name;
                    _temp.Email = user.Email;
                    _temp.Password = user.Password;
                    _context.Add(_temp);
                    model.Messsage = "User Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public async Task<ResponseModel> DeleteUser(int userId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                User _temp = await GetUserDetailsById(userId);
                if (_temp != null)
                {
                    _context.Remove(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "User Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "User Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
        #endregion
    }
}
