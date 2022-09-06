using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nazli.Business.Abstract;
using Nazli.Business.Concrete;

namespace Nazli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        GroupManager _groupManager;

        public GroupsController(GroupManager groupManager)
        {
            _groupManager = groupManager;
        }
    }
}
