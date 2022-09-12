﻿using System;
using System.Collections.Generic;

namespace Nazli.DataLayer.Entity
{
    public partial class User
    {
        public User()
        {
            Complains = new HashSet<Complain>();
            FriendRequestedUsers = new HashSet<Friend>();
            FriendRequesterUsers = new HashSet<Friend>();
            GroupMemberAddedUsers = new HashSet<GroupMember>();
            GroupMemberUsers = new HashSet<GroupMember>();
            Groups = new HashSet<Group>();
            MessageReceivers = new HashSet<Message>();
            MessageSenders = new HashSet<Message>();
        }

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Username { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? ProfilePhoto { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<Complain> Complains { get; set; }
        public virtual ICollection<Friend> FriendRequestedUsers { get; set; }
        public virtual ICollection<Friend> FriendRequesterUsers { get; set; }
        public virtual ICollection<GroupMember> GroupMemberAddedUsers { get; set; }
        public virtual ICollection<GroupMember> GroupMemberUsers { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Message> MessageReceivers { get; set; }
        public virtual ICollection<Message> MessageSenders { get; set; }
    }
}
