using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nazli.Business.Abstract;
using Nazli.Business.Concrete;
using Nazli.Common.DTOs;

namespace Nazli.API.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //IUserService _userService;

        //public UsersController(IUserService userService)
        //{
        //    _userService = userService;
        //}
        UserManager _userManager;

        public UsersController(UserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Add")]

        public IActionResult Add([FromBody] UserDto dto)
        {
            var result = _userManager.Add(dto);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return NotFound(result.Errors);
        }

        [Route("Update")]
        [HttpPut]

        public IActionResult Update([FromBody] UserDto dto)
        {
            var result = _userManager.Update(dto);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return NotFound(result.Errors);
        }

        //[HttpDelete("Delete")]
        //public IActionResult Delete([FromBody] UserDto dto)
        //{
        //    var result = _userManager.Delete(dto);
        //    if (result.Errors != null)
        //    {
        //        return NotFound(result.Value);

        //    }
        //    return NotFound(result.Errors);
        //}


        [HttpDelete("Delete")]

        public IActionResult Delete(int userId)
        {
            var result = _userManager.Delete(userId);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }



    }
}
