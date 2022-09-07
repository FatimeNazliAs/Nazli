using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nazli.Business.Abstract;
using Nazli.Business.Concrete;
using Nazli.Common.DTOs;

namespace Nazli.API.Controllers
{
    [Route("Group")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        GroupManager _groupManager;

        public GroupsController(GroupManager groupManager)
        {
            _groupManager = groupManager;
        }
        
        [HttpPost("Add")]
        public IActionResult Add([FromBody] GroupDto group)
        {
            var result=_groupManager.Add(group);
            if (result.Errors!=null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] GroupDto group)
        {
            var result = _groupManager.Update(group);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int groupId)
        {
            var result = _groupManager.Delete(groupId);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet("GetById/{groupId}")]
        public IActionResult GetById(int groupId)
        {
            var result = _groupManager.GetById(groupId);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }
    }


        
}
