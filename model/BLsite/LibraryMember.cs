using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLsite
{
    public class LibraryMember
    {
         [Key]
        public int MemberId { get; set; }      // Clé primaire
        public string FullName { get; set; }
        public string Email { get; set; }

       public string GetInfos()
        {
            return $"Library Member with Full Name {FullName} , Email \" {Email}\"\r\n";
        }


    }
}
