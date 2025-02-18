using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLsite
{
    public abstract class Book 
    {
        [Key]
        public int Id { get; set; }
        public int Serial {  get;  set; }
       public string? Title { get;  set; }
        public int? Value { get;  set; }
        public int? AuthorId {  get; set; }
        [ForeignKey("AuthorId ")]
      public virtual Author Author { get; set; }


        public string getInfos()
        {
            return $"Book Details: Serial {Serial}, Title \"{Title ?? "Unknown Title"}\", " +
                   $"Author: {Author?.Name ?? "Unknown Author"}, Value: {Value?.ToString() ?? "N/A"}";
        }


        public void CalculatedValue()
        {
            int wordCount = Title.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
            Value += wordCount * 5;
            Value += Title.Count(char.IsUpper) * 3;

            if (Title.ToLower().Contains("smurf"))
            {
                Value += 10;
            }

            if (Serial < 100)
            {
                Value *= 2;
            }

        }
        public abstract void CalculatedExtandedValue();
        public abstract string GetExtandedInfos();
    }
}
