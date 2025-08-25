using MediatR;
using Domain.Users;
using Application.Users;

namespace Recipes.Application.Users.Queries
{
    

    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User?>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByIdAsync(request.Id);
        }
    }

}
