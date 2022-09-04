using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nazli.Business.Abstract;
using Nazli.Common.DTOs;

namespace Nazli.API.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("Add")]
        [HttpPost]

        public IActionResult Add([FromBody] UserDto dto)
        {
            var result = _userService.Add(dto);
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
            var result = _userService.Update(dto);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return NotFound(result.Errors);
        }


    }
}
