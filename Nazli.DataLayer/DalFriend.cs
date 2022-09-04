using Nazli.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nazli.DataLayer
{
    public class DalFriend : DalBase<Friend>
    {
        ChatAppContext chatAppContext = new ChatAppContext();
        public List<Friend> GetList(int id)
        {
            return chatAppContext.Set<Friend>()
                                 .Where(x => x.FriendId == id)
                                 .ToList();
        }
     
  
    
    
    }
}
