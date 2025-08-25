using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Recipes;
using MediatR;

namespace Recipes.Application.Recipes.Commands
{
    public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand, Unit>
    {
        private readonly IRecipeRepository _recipeRepo;

        public DeleteRecipeCommandHandler(IRecipeRepository recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        public async Task<Unit> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepo.GetByIdAsync(request.RecipeId);
            if (recipe == null)
                throw new KeyNotFoundException("Recipe not found");

            await _recipeRepo.DeleteAsync(recipe);
            return Unit.Value;
        }
    }
}
