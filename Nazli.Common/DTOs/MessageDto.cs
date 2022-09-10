using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nazli.Common.DTOs
{
    public class MessageDto
    {

        public int MessageId { get; set; }
        [Required()]
        public int SenderId { get; set; }
        [Required()]
        public int? ReceiverId { get; set; }
        [Required()]

        public int? GroupId { get; set; }
        [Required()]
        public string MessageContent { get; set; } = null!;
        [Required()]
        public DateTime SendDate { get; set; }
        [Required()]
        public DateTime ReadDate { get; set; }
        [Required()]



    }
}
