using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Likes;
using MediatR;
namespace Recipes.Application.Likes.Commands
{
    
    public class ToggleLikeCommandHandler : IRequestHandler<ToggleLikeCommand, int>
    {
        private readonly ILikeRepository _likeRepo;

        public ToggleLikeCommandHandler(ILikeRepository likeRepo)
        {
            _likeRepo = likeRepo;
        }

        public async Task<int> Handle(ToggleLikeCommand request, CancellationToken cancellationToken)
        {
            var existing = await _likeRepo.GetByUserAndRecipeAsync(request.UserId, request.RecipeId);

            if (existing != null)
            {
                await _likeRepo.RemoveAsync(existing);
            }
            else
            {
                await _likeRepo.AddAsync(new Like(request.RecipeId, request.UserId));
            }

            return await _likeRepo.CountByRecipeAsync(request.RecipeId);
        }
    }
    

}
