using Nazli.Common.DTOs;
using Nazli.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nazli.Business.Abstract
{
    public interface IGroupMemberService : IBaseService<GroupMemberDto>
    {
        List<GroupMember> GetListAll();

    }
}
