﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nazli.Common.DTOs
{
    public class UserDto
    {
      

        public int UserId { get; set; }
       // [Required()]
        public string Name { get; set; } 
       
        public string Surname { get; set; }
      //  [Required()]
        public string Username { get; set; }
      
        public string Email { get; set; } 
        
        public string Password { get; set; } 
   
        public string? ProfilePhoto { get; set; }
      
        public DateTime CreateDate { get; set; }

        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }


    }
}