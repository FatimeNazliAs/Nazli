using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nazli.Business.Abstract;
using Nazli.Business.Concrete;
using Nazli.Common.DTOs;

namespace Nazli.API.Controllers
{
    [Route("Complain")]
    [ApiController]
    public class ComplainsController : ControllerBase
    {
        IComplainService _complainService;
         public ComplainsController(IComplainService complainService)
        {
            _complainService = complainService;
        }
      

        [Route("Add")]
        [HttpPost]

        public IActionResult Add([FromBody] ComplainDto dto)
        {
            var result = _complainService.Add(dto);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return NotFound(result.Errors);
        }

        
        [Route("Update")]
        [HttpPut]

        public IActionResult Update([FromBody] ComplainDto dto)
        {
            var result = _complainService.Update(dto);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return NotFound(result.Errors);
        }


    }
}
