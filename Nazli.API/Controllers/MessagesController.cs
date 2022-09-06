using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nazli.Business.Abstract;
using Nazli.Business.Concrete;
using Nazli.Common.DTOs;
using Nazli.DataLayer.Entity;
using System;

namespace Nazli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        MessageManager _messageManager;

        public MessagesController(MessageManager messageManager)
        {
            _messageManager = messageManager;
        }


        [HttpPost]

        public IActionResult SendMessage([FromBody] MessageDto message)
        {
            var result = _messageManager.SendMessage(message);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        
        [HttpDelete]

        public IActionResult Delete(int messageId)
        {
            var result = _messageManager.Delete(messageId);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        //[HttpGet()] //URL EKLE
        //public IActionResult GetPrivateMessage(int senderId,int receiverId)
        //{
        //    var result = _messageManager.GetPrivateMessage(senderId,  receiverId);
        //    if (result.Errors != null)
        //    {
        //        return BadRequest(result.Errors);

        //    }
        //    return Ok(result.Value);

        //}
        //[HttpGet] //URL EKLE
        //public IActionResult GetGroupMessage(int senderId, int groupId)
        //{
        //    var result = _messageManager.GetPrivateMessage(senderId, groupId);
        //    if (result.Errors != null)
        //    {
        //        return BadRequest(result.Errors);

        //    }
        //    return Ok(result.Value);

        //}


    }
}
