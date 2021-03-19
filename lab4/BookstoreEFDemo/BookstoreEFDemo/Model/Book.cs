using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreEFDemo.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public Author Author { get; set; }

        public override string ToString()
        {
            return Id + ". " + Title +
                ((Author != null) ? (", by " + Author) : "");
        }
    }
}
