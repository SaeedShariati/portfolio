using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio.Models
{
    public class Comment
    {
        public long Id { get; set; }
        [MaxLength(20,ErrorMessage ="بیشتر از 20 کاراکتر نباید باشد")]
        public string Author { get; set; }
        [Required]
        [MaxLength(280,ErrorMessage ="متن بیش از 280 کاراکتر است")]
        public string Text { get; set; }
        [Required]
        public int Rating { get; set; } // 1 to 10
        public Post Post { get; set; }
    }
}
