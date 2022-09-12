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
using System.Text.RegularExpressions;

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

       
        
        
        public BCResponse GetGroupMessage(int SenderId, int GroupId)
        {
            var isExistGroup = _dalMessage.getMember(userId: SenderId, groupId: GroupId);


            if (isExistGroup != null)
            {
                return new BCResponse() { Value = isExistGroup };
            }
            return new BCResponse() { Errors = "Group Mesajı alınamadı" };
        }

        public BCResponse GetPrivateMessage(int SenderId, int ReceiverId)
        {
            var senderResult = _dalMessage.GetBy(senderId: SenderId);
            var receiverResult = _dalMessage.GetBy(receiverId: ReceiverId);


            if (senderResult != null && receiverResult != null)
            {
                return new BCResponse() { Value = senderResult };
            }
            return new BCResponse() { Errors = "İki kişi arasında mesaj bulunamadı." };
        }

        
        public BCResponse SendMessage(MessageDto message) // TEKRAR BAK! 
        {
            #region Business
            Message newMessage = new Message();
         

            if (message.GroupId == 0)
            {
                var isFriend = _dalMessage.GetFriend(senderId: message.SenderId, receiverId: message.ReceiverId);
                if (isFriend == null)
                {
                    return new BCResponse() { Errors = "Arkadaş olunmayan kişiye mesaj gönderilemez." };
                }

                newMessage.SenderId = message.SenderId;
                newMessage.ReceiverId = message.ReceiverId;
                newMessage.MessageContent = message.MessageContent;
                newMessage.SendDate = message.SendDate;
                newMessage.ReadDate = message.ReadDate;
            }
            else if (message.ReceiverId == 0)
            {
                var isGroup = _dalMessage.getMember(userId: message.SenderId, groupId: message.GroupId);
                if (isGroup == null)
                {
                    return new BCResponse() { Errors = "Grupta olmayan kullanıcı gruba mesaj gönderemez" };
                }
                newMessage.SenderId = message.SenderId;
                newMessage.GroupId = message.GroupId;
                newMessage.MessageContent = message.MessageContent;
                newMessage.SendDate = message.SendDate;
                newMessage.ReadDate = message.ReadDate;

            }
            else
            {
                return new BCResponse() { Errors = "Mesaj aynı anda gruba ve kişiye gönderilemez." };

            }

            #endregion


            #region Send Message
            var result = _dalMessage.Add(newMessage);
            if (result != 0)
            {
                return new BCResponse() { Value = result };
            }

            return new BCResponse() { Errors = "Sistem Hatası" };
            #endregion

        }



    }
}
