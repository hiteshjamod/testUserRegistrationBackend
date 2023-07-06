using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Contract;
using UserRegistration.Models;
using UserRegistration.ViewModel;

namespace UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Variables and constructor

        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _userService.GetUserList();
                if (users == null)
                    return NotFound();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var users = await _userService.GetUserDetailsById(id);
                if (users == null) return NotFound();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserViewModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = await _userService.SaveUser(userModel);
                    return Ok(model);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await _userService.DeleteUser(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
