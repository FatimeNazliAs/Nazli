using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nazli.Business.Abstract;
using Nazli.Business.Concrete;

namespace Nazli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        FriendManager _friendManager;

        public FriendsController(FriendManager friendManager)
        {
            _friendManager = friendManager;
        }
   
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}
