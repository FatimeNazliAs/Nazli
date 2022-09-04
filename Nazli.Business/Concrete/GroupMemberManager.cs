using Nazli.Business.Abstract;
using Nazli.Common.DTOs;
using Nazli.Common.Utilities.Results;
using Nazli.DataLayer;
using Nazli.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nazli.Business.Concrete
{
    public class GroupMemberManager : IGroupMemberService
    {
        ChatAppContext chatAppContext = new ChatAppContext();
        DalGroupMember _dalGroupMember;

        public GroupMemberManager(DalGroupMember dalGroupMember)
        {
            _dalGroupMember = dalGroupMember;
        }

        public BCResponse Add(GroupMemberDto dto)
        {
            throw new NotImplementedException();

        }

        public BCResponse Delete(GroupMemberDto dto)
        {
            throw new NotImplementedException();
        }

        public BCResponse Update(GroupMemberDto dto)
        {
            throw new NotImplementedException();
        }

        public List<GroupMember> GetListAll()
        {
            return chatAppContext.Set<GroupMember>().ToList();

        }
    }
}
