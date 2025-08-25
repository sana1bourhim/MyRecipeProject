using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain.Users;
using BCrypt.Net;
using global::Application.Users;


namespace Recipes.Application.Users.Commands
{
 

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Hash du mot de passe
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // Créer l'utilisateur
            var user = new User(request.Email, hashedPassword);

            // Sauvegarder
            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }

}
