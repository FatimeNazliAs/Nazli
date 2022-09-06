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
            var groupResult = _dalMessage.GetBy(groupId: GroupId);
            var senderResult = _dalMessage.GetBy(senderId: SenderId);


            if ( groupResult != null && senderResult != null)
            {
                return new BCResponse() { Value = senderResult };
            }
            return new BCResponse() { Errors = "Grup Mesajı alınamadı" };
        }

        public BCResponse GetPrivateMessage(int SenderId, int ReceiverId)
        {
            var senderResult = _dalMessage.GetBy(senderId: SenderId);
            var receiverResult = _dalMessage.GetBy(receiverId: ReceiverId);
            

            if ((senderResult != null && receiverResult == null) || (senderResult != null && receiverResult != null))
            {
                return new BCResponse() { Value = senderResult };
            }
            return new BCResponse() { Errors = "Mesaj alınamadı" };
        }

        
        public BCResponse SendMessage(MessageDto message) // TEKRAR BAK! 
        {
            // throw new NotImplementedException();

            //MessageDto dto;
            #region Business
            var senderResult = _dalMessage.GetBy(senderId: message.SenderId);
            var receiverResult= _dalMessage.GetBy(receiverId: message.ReceiverId);
            
            if (senderResult == null )
            {
                
                
                if (receiverResult != null)
                {
                    return new BCResponse() { Errors = "Gonderici bulunamadı" };
                    

                }
                else
                {
                    return new BCResponse() { Errors = "Gonderici ve Alıcı bulunamadı" };
                }


            }


            
            var groupResult = _dalMessage.GetBy(groupId: message.GroupId);

            if ((groupResult == null && senderResult == null) || (groupResult == null && senderResult!= null))
            {
                return new BCResponse() { Errors = "Grup mesajı yok" };

            }
            #endregion
            #region Map to Entity

            Message entity = new Message();
            entity.SenderId = message.SenderId;
            entity.ReceiverId=message.ReceiverId;
            entity.MessageReferenceId=message.MessageReferenceId;
            entity.GroupId= message.GroupId;
            entity.MessageContent = message.MessageContent;
            entity.SendDate= message.SendDate;
            entity.ReadDate= message.ReadDate;

            #endregion


            if((senderResult!=null && receiverResult!=null) || (senderResult != null && receiverResult == null))
            {
                var result = _dalMessage.SendMessage(entity);
                if (result !=null)
                {
                    return new BCResponse() { Value = result };
                }

                return new BCResponse() { Errors = "Sistem Hatası" };
            }

            return new BCResponse() { Errors = "Mesaj atmak için gereklilikler sağlanamadı" };


        }



    }
}
