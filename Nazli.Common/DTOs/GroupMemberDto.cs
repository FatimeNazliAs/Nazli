using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nazli.Common.DTOs
{
    public class GroupMemberDto
    {


        public int GroupMemberId { get; set; }
        [Required()]
        public int GroupId { get; set; }
        [Required()]
        public int UserId { get; set; }
        [Required()]
        public int AddedUserId { get; set; }
        [Required()]
        public DateTime AddedDate { get; set; }
        [Required()]
        public bool IsAdmin { get; set; }
        [Required()]





    }
}
