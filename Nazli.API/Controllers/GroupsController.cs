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
        
        [HttpPost]
        public IActionResult Add([FromBody] GroupDto group)
        {
            var result=_groupManager.Add(group);
            if (result.Errors!=null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpPut]
        public IActionResult Update([FromBody] GroupDto group)
        {
            var result = _groupManager.Update(group);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }
        [HttpDelete]
        public IActionResult Delete(int groupId)
        {
            var result = _groupManager.Delete(groupId);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet]
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
