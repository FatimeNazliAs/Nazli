using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nazli.Business.Abstract;
using Nazli.Business.Concrete;

namespace Nazli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMembersController : ControllerBase
    {
        GroupMemberManager _groupMemberManager;

        public GroupMembersController(GroupMemberManager groupMemberManager)
        {
            _groupMemberManager = groupMemberManager;
        }
    }
}
