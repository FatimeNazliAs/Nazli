using Nazli.Common.DTOs;
using Nazli.Common.Utilities.Results;
using Nazli.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nazli.Business.Abstract
{
    public interface IMessageService: IBaseService<MessageDto>
    {
        //List<Message> GetPrivateMessage(int senderId, int receiverId);
        //List<Message> GetGroupMessage(int senderId, int groupId);

        //Message SendMessage(Message message);

        BCResponse GetPrivateMessage(int senderId, int receiverId);
        BCResponse GetGroupMessage(int senderId, int groupId);

        BCResponse SendMessage(MessageDto message);
    }
}
