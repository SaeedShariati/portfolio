using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio.Models
{
    public interface IPostRepository
    {
        public IQueryable<Post> Posts { get; }
        void SavePost(Post post);
        Post DeletePost(int PostId);
    }
}
