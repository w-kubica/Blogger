﻿using Blogger.Domain.Entities;
using Blogger.Domain.Interfaces;
using Blogger.Infrastructure.Data;
using Blogger.Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BloggerContext _context;

        public PostRepository(BloggerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Post>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
        {
            return await _context.Posts
                .Where(x => x.Title.ToLower().Contains(filterBy.ToLower()) || x.Content.ToLower().Contains(filterBy.ToLower()))
                .OrderByPropertyName(sortField,ascending)
                .Skip((pageNumber-1)*pageSize).Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetAllCountAsync(string filterBy)
        {
            return await _context.Posts
                .Where(x => x.Title.ToLower().Contains(filterBy.ToLower()) || x.Content.ToLower().Contains(filterBy.ToLower()))
                .CountAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _context.Posts.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Post> AddAsync(Post post)
        {
            var createdPost = await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return createdPost.Entity;
        }

        public async Task UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Post post)
        {
            _context.Posts.Remove(post);
           await _context.SaveChangesAsync();
        }
    }
}
