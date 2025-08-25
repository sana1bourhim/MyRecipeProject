using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Likes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipes.Application.Likes
{
    public interface ILikeRepository
    {
        Task<Like> GetByRecipeAndUserAsync(Guid recipeId, Guid userId);
        Task<int> ToggleLikeAsync(Guid recipeId, Guid userId);
        Task<Like> GetByUserAndRecipeAsync(Guid userId, Guid recipeId);
        Task AddAsync(Like like);

        Task RemoveAsync(Like like);

        Task<int> CountByRecipeAsync(Guid recipeId);
    }

}
