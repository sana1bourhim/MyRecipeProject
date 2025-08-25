using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Likes;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Recipes.Application.Likes;

namespace Recipes.Infrastructure.Repositories
{
    // LikeRepository.cs
    public class LikeRepository : ILikeRepository
    {
        private readonly AppDbContext _context;
        public LikeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Like> GetByRecipeAndUserAsync(Guid recipeId, Guid userId)
        {
            return await _context.Likes
                .FirstOrDefaultAsync(l => l.RecipeId == recipeId && l.UserId == userId);
        }
        public async Task<Like> GetByUserAndRecipeAsync(Guid userId, Guid recipeId)
        {
            return await _context.Likes
                .FirstOrDefaultAsync(l => l.UserId == userId && l.RecipeId == recipeId);
        }
        public async Task AddAsync(Like like)
        {
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Like like)
        {
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountByRecipeAsync(Guid recipeId)
        {
            return await _context.Likes.CountAsync(l => l.RecipeId == recipeId);
        }

        public async Task<int> ToggleLikeAsync(Guid recipeId, Guid userId)
        {
            var like = await GetByRecipeAndUserAsync(recipeId, userId);
            if (like == null)
            {
                _context.Likes.Add(new Like(recipeId, userId));
            }
            else
            {
                _context.Likes.Remove(like);
            }
            await _context.SaveChangesAsync();
            return await _context.Likes.CountAsync(l => l.RecipeId == recipeId);
        }
    }


}
