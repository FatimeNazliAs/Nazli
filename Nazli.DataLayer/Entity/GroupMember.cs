﻿using Nazli.Common.DataLayer.Entities;
using System;
using System.Collections.Generic;

namespace Nazli.DataLayer.Entity
{
    public partial class GroupMember 
    {
        public int GroupMemberId { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public int AddedUserId { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsAdmin { get; set; }

       
    }
}