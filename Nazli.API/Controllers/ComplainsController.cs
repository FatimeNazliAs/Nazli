using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nazli.Business.Concrete;
using Nazli.Common.DTOs;

namespace Nazli.API.Controllers
{
    [Route("Complain")]
    [ApiController]
    public class ComplainsController : ControllerBase
    {
        ComplainManager _complainManager;

        public ComplainsController(ComplainManager complainManager)
        {
            _complainManager = complainManager;
        }

        [HttpPost]
        public IActionResult Add([FromBody] ComplainDto dto)
        {
            var result = _complainManager.Add(dto);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return Ok(result.Errors);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _complainManager.Delete(id);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return Ok(result.Errors);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ComplainDto dto)
        {
            var result = _complainManager.Update(dto);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return Ok(result.Errors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _complainManager.GetById(id);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }


        [HttpGet]
        public IActionResult GetListAll()
        {
            var result = _complainManager.GetListAll();
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet("getcomplainbyuserıd/{id}")]
        public IActionResult GetComplainByUserID(int id)
        {
            var result = _complainManager.GetComplainByUserID(id);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }
    }
}
