﻿using Nazli.Common.DataLayer.Entities;
using System;
using System.Collections.Generic;

namespace Nazli.DataLayer.Entity
{
    public partial class Message 
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int MessageReferenceId { get; set; }
        public int? ReceiverId { get; set; }
        public int? GroupId { get; set; }
        public string MessageContent { get; set; } = null!;
        public DateTime SendDate { get; set; }
        public DateTime ReadDate { get; set; }

        public virtual Group? Group { get; set; }
        public virtual User? Receiver { get; set; }
        public virtual User Sender { get; set; } = null!;
    }
}
