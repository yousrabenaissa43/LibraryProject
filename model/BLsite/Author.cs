using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLsite
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }      // Clé primaire
        public string Name { get; set; }
        public string Biography { get; set; }

        public string getInfos()
        {
            return $"Author with Name {Name} , Biography  \" {Biography}\"\r\n";
        }

    }
}
