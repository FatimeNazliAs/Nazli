﻿using Nazli.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nazli.DataLayer
{
    public class DalGroupMember : DalBase<GroupMember>
    {
        ChatAppContext chatAppContext = new ChatAppContext();
        public List<GroupMember> GetListAll()
        {
            return chatAppContext.Set<GroupMember>().ToList();

        }
        public bool Any(int? groupMemberId = null, int? groupId = null, int? userId = null, int? addedUserId = null,string ? name = null, int? createrUserId = null)
        {

            return chatAppContext.GroupMembers.
                Any(x =>
                            (!groupMemberId.HasValue || x.GroupMemberId == groupMemberId) &&
                            (!groupId.HasValue || x.GroupId == groupId) &&
                            (!addedUserId.HasValue || x.AddedUserId == addedUserId) &&
                            (!userId.HasValue || x.UserId == userId));


        }

        public Group? GetBy(int? id = null, int? createrUserId = null, string? name = null)
        {

            return chatAppContext.GroupMembers.
                Where(x =>
                            (!id.HasValue || x.GroupId == id) &&
                            (!createrUserId.HasValue || x.CreaterUserId == createrUserId) &&
                            (string.IsNullOrEmpty(name) || x.Name == name)).FirstOrDefault();

        }

    }
}
