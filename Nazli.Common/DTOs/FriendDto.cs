using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nazli.Common.DTOs
{
    public class FriendDto
    {
        public int FriendId { get; set; }
        public int RequesterUserId { get; set; } //istek gönderen
        public int RequestedUserId { get; set; } //istek kabul eden
        public byte FriendStatusId { get; set; }
        public DateTime RequestedDate { get; set; }
     

    }
}
