using Nazli.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


    }
}
