using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogger.Domain.Entities;
using Blogger.Domain.Interfaces;
using Blogger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Infrastructure.Repositories
{
    public  class PostRepository : IPostRepository
    {
        private readonly BloggerContext _context;

        public PostRepository(BloggerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            var posts = _context.Posts;
            return await _context.Posts.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Post> AddAsync(Post post)
        {
            var createdPost = await _context.Posts.AddAsync(post);
            _context.Posts.Add(post);
            _context.SaveChangesAsync();
            return createdPost.Entity;
        }

        public async Task UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
