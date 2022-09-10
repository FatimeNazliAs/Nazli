using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Nazli.Business.Abstract;
using Nazli.Business.Concrete;
using Nazli.Common.DTOs;
using Nazli.DataLayer.Entity;

namespace Nazli.API.Controllers
{
    [Route("GroupMember")]
    [ApiController]
    public class GroupMembersController : ControllerBase
    {
        GroupMemberManager _groupMemberManager;

        public GroupMembersController(GroupMemberManager groupMemberManager)
        {
            _groupMemberManager = groupMemberManager;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] GroupMemberDto groupMember)
        {
            var result = _groupMemberManager.Add(groupMember);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] GroupMemberDto groupMember)
        {
            var result = _groupMemberManager.Update(groupMember);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int groupId)
        {
            var result = _groupMemberManager.Delete(groupId);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet("GetById/{groupId}")]
        public IActionResult GetById(int groupId)
        {
            var result = _groupMemberManager.GetById(groupId);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }
    }
}
