using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nazli.Business.Abstract;
using Nazli.Business.Concrete;
using Nazli.Common.DTOs;

namespace Nazli.API.Controllers
{
    [Route("Friend")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        FriendManager _friendManager;

        public FriendsController(FriendManager friendManager)
        {
            _friendManager = friendManager;
        }

        [HttpPost]
        public IActionResult Add([FromBody]  FriendDto friend)
        {
            var result = _friendManager.Add(friend);
            if (result.Errors!=null)
            {
                return BadRequest(result.Errors);   

            }
            return Ok(result.Value);
        }

        [HttpPut]
        public IActionResult Update([FromBody] FriendDto friend)
        {
            var result = _friendManager.Update(friend);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpDelete]
        public IActionResult Add(int id)
        {
            var result = _friendManager.Delete(id);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _friendManager.GetById(id);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }












    }
}
