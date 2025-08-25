using Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Recipes;

public interface IRecipeRepository
{
    Task AddAsync(Recipe recipe);
    Task<Recipe?> GetByIdAsync(Guid id);
    Task<IEnumerable<Recipe>> GetAllAsync();
    Task UpdateAsync(Recipe recipe);
    Task DeleteAsync(Recipe recipe);
}
