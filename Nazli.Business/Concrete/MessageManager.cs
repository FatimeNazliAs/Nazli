using Nazli.Business.Abstract;
using Nazli.Common.DTOs;
using Nazli.Common.Utilities.Results;
using Nazli.DataLayer.Entity;
using Nazli.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nazli.Business.Concrete
{
    public class MessageManager : IMessageService
    {
        ChatAppContext chatAppContext = new ChatAppContext();
        DalMessage _dalMessage;

        public MessageManager(DalMessage dalMessage)
        {
            _dalMessage = dalMessage;
        }

        public BCResponse Add(MessageDto dto)
        {
            throw new NotImplementedException();
        }

        public BCResponse Update(MessageDto dto)
        {
            throw new NotImplementedException();
        }

        public BCResponse Delete(int id)
        {
            #region Business
            if (id <= 0)
            {
                return new BCResponse() { Errors = "hatalı veri" };
            }
            #endregion
            #region Delete
            Message? entity = chatAppContext.Messages.
                               FirstOrDefault(u => u.MessageId== id);
            
            if (entity != null)
            {
                _dalMessage.Delete(entity);
                return new BCResponse() { Value = entity };

            }
            #endregion
            return new BCResponse() { Errors = "Mesaj silinemedi" };


        }

       
        
        
        public List<Message> GetGroupMessage(int senderId, int groupId)
        {
            return chatAppContext.Set<Message>()
                               .Where(m => m.SenderId == senderId && m.GroupId == groupId)
                               .ToList();
        }

        public List<Message> GetPrivateMessage(int senderId, int receiverId)
        {
            return chatAppContext.Set<Message>()
                                 .Where(m => m.SenderId == senderId && m.ReceiverId == receiverId)
                                 .ToList();
        }

        public Message SendMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
