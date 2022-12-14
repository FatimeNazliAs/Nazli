using Nazli.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nazli.DataLayer
{
    public class DalMessage : DalBase<Message>
    {
        ChatAppContext chatAppContext = new ChatAppContext();


        public List<Message> GetPrivateMessage(int senderId,int receiverId)
        {
            return chatAppContext.Set<Message>()
                                 .Where(m => m.SenderId == senderId && m.ReceiverId == receiverId)
                                 .ToList();
        }

        public List<Message> GetGroupMessage(int senderId, int groupId)
        {
            return chatAppContext.Set<Message>()
                                 .Where(m => m.SenderId == senderId && m.GroupId == groupId)
                                 .ToList();
        }

        public Message SendMessage(Message message)
        {
            return message;
        }


        public bool Any(int? messageId = null,int? senderId=null, int? receiverId=null)
        {

            return chatAppContext.Messages.
                Any(x =>
                            (!messageId.HasValue || x.MessageId == messageId) &&
                            (!senderId.HasValue || x.SenderId == senderId) &&
                            (!receiverId.HasValue || x.ReceiverId == receiverId));
                           // (!messageReferenceId.HasValue || x.MessageReferenceId == messageReferenceId));



        }

        public Message? GetBy(int? messageId = null, int? senderId = null, int? receiverId = null, int? groupId=null)
        {

            return chatAppContext.Messages.
                Where(x =>
                            (!messageId.HasValue || x.MessageId == messageId) &&
                            (!senderId.HasValue || x.SenderId == senderId) &&
                            (!receiverId.HasValue || x.ReceiverId == receiverId) &&
                            (!groupId.HasValue || x.GroupId == groupId)).FirstOrDefault();
                        


        }

   
        public GroupMember? GetMember(int? userId,int? groupId)
        {
            return chatAppContext.GroupMembers
              .FirstOrDefault(c=>c.UserId==userId && c.GroupId==groupId);
               //.FirstOrDefault(c => c.UserId == groupId && c.GroupId == userId);
        }
        public Friend? GetFriend(int? senderId = null, int? receiverId = null)
        {
            return chatAppContext.
                Friends.              
                 FirstOrDefault(c => c.RequesterUserId == receiverId && c.RequestedUserId == senderId);
        }

    }
}
