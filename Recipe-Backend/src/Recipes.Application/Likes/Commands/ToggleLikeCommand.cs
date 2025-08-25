using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;


namespace Recipes.Application.Likes.Commands
{

  public record ToggleLikeCommand(Guid RecipeId, Guid UserId) : IRequest<int>; 
    

}
