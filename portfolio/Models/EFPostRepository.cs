using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio.Models
{
    public class EFPostRepository : IPostRepository
    {
        ApplicationDbContext Context;
        public EFPostRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public IQueryable<Post> Posts => Context.Posts.Include(p=>p.Author).Include(p=>p.Comments);

        public Post DeletePost(int PostId)
        {
            Post post = Context.Posts.FirstOrDefault(p => p.Id == PostId);
            if(post != null)
            {
                Context.Posts.Remove(post);
                Context.SaveChanges();
            }
            return post;
        }

        public void SavePost(Post post)
        {
            if(post.Id == 0)
            {
                Context.Posts.Add(post);
            }
            else
            {
                Post p = Context.Posts.FirstOrDefault(po => po.Id == post.Id);
                p.Author = post.Author;
                p.Comments = post.Comments;
                p.Created = post.Created;
                p.Header = post.Header;
                p.ImageName = post.ImageName;
                p.Text = post.Text;
                p.Tags = post.Tags;
            }
            Context.SaveChanges();
        }
    }
}
