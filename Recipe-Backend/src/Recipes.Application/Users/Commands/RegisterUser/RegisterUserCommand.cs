using Org.BouncyCastle.Crypto.Generators;
using Domain.Users;
using MediatR;
using global::Application.Users;

namespace Recipes.Application.Users.Commands.RegisterUser
{



    public record RegisterUserCommand(string Username, string Email, string Password) : IRequest<Guid>;

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                throw new Exception("Email déjà utilisé.");

            // hash du mot de passe
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User(request.Username, request.Email, passwordHash);
            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }

}
