using Nazli.Common.DataLayer.Entities;
using System;
using System.Collections.Generic;

namespace Nazli.DataLayer.Entity
{
    public partial class Complain
    {
        public int ComplainId { get; set; }
        public int ComplainantUserId { get; set; }
        public int ComplainedOfUserId { get; set; }
        public byte ComplainStatusId { get; set; }
        public DateTime ComplainDate { get; set; }

        public virtual ComplainStatus ComplainStatus { get; set; } = null!;
        public virtual User ComplainantUser { get; set; } = null!;
        public virtual User ComplainedOfUser { get; set; } = null!;
    }
}
