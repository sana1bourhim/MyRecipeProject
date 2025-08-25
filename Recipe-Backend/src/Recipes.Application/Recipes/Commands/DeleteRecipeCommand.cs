using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Recipes.Application.Recipes.Commands
{
    public class DeleteRecipeCommand : IRequest<Unit>
    {
        public Guid RecipeId { get; set; }

        public DeleteRecipeCommand(Guid recipeId)
        {
            RecipeId = recipeId;
        }
    }
}
