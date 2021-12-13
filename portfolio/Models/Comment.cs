using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public int stars { get; set; } // 1 to 5
        public Post Post { get; set; }
    }
}
