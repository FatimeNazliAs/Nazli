using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nazli.Common.DTOs
{
    public class FriendDto
    {
        public int FriendId { get; set; }
        [Required()]
        public int RequesterUserId { get; set; } //istek gönderen
        [Required()]
        public int RequestedUserId { get; set; } //istek kabul eden
        [Required()]
        public byte FriendStatusId { get; set; }
        [Required()]
        public DateTime RequestedDate { get; set; }
  


    }
}
