using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UserManagementSystem.Model;
using UserManagementSystem.Services;

namespace UserManagementSystem.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        StatusCodeResult status = new StatusCodeResult(200);
        public UsersController(UserService userService)
        {
            _userService = userService;
        }


        [HttpGet("Get Users")]
        public ActionResult<List<User>> GetUsers(UserCredentials userCredentialsParam)
        {
            //return _userService.GetUsers(userCredentialsParam);
            var user = _userService.GetUsers(userCredentialsParam);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("Get User By {id:length(24)}", Name = "GetUser")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetUserById(UserCredentials userCredentialsParam,string id)
        {
            var user = _userService.GetUserById(userCredentialsParam, id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost("Add User {id:length(24)}")]
        public ActionResult<User> AddUser(UserCredentials userCredentialsParam, User user)
        {
            _userService.AddUser(userCredentialsParam, user);
            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }


        [HttpPut("Update User {id:length(24)}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUserById(UserCredentials userCredentialsParam, string id, User user)
        {
            var item = _userService.GetUserById(userCredentialsParam, id);
            if (item == null)
            {
                return NotFound();
            }
            _userService.UpdateUserById(userCredentialsParam, id, user);
            return Ok(user);
        }


        [HttpDelete("Remove User {id:length(24)}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RemoveUserById(UserCredentials userCredentialsParam, string id)
        {
            var user = _userService.GetUserById(userCredentialsParam, id);

            if (user == null)
            {
                return NotFound();
            }
            _userService.RemoveUserById(userCredentialsParam, user.Id);
            return Ok(user);
        }

        [HttpPost("Search Users")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<User>> GetSearchedUsers(UserCredentials userCredentialsParam , string name, string userName, string zipCode, string companyName)
        {
            var users = _userService.GetSearchedUsers(userCredentialsParam, name, userName, zipCode, companyName);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
    }
}