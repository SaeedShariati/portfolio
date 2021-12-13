using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio.Models
{
    public class Author
    {
        public long Id { get; set; }
        [Required]
        public string Username { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        public ICollection<Post> Posts { get; set; }
        public int Rating { get; set; }
    }
}
