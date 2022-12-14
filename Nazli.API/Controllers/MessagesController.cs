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
    [Route("Message")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        MessageManager _messageManager;

        public MessagesController(MessageManager messageManager)
        {
            _messageManager = messageManager;
        }


        [HttpPost("SendMessage")]

        public IActionResult SendMessage([FromBody] MessageDto message)
        {
            var result = _messageManager.SendMessage(message);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        
        [HttpDelete("Delete")]

        public IActionResult Delete(int messageId)
        {
            var result = _messageManager.Delete(messageId);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet("user/{senderId}/groupchat/{receiverId}/Message")] 
        public IActionResult GetPrivateMessage(int senderId, int receiverId)
        {
            var result = _messageManager.GetPrivateMessage(senderId, receiverId);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);

        }
        
        [HttpGet("user/{senderID}/groupchat/{groupID}")] 
        public IActionResult GetGroupMessage(int senderId, int groupId)
        {
            var result = _messageManager.GetPrivateMessage(senderId, groupId);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);

        }


    }
}
