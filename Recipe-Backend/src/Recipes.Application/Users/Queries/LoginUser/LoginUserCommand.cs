using Domain.Users;
using MediatR;

using Org.BouncyCastle.Crypto.Generators;

namespace Application.Users.Queries;

public record LoginUserQuery(string Email, string Password) : IRequest<User?>;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, User?>
{
    private readonly IUserRepository _userRepository;

    public LoginUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null) return null;

        // vérifier le mot de passe
        bool valid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
        return valid ? user : null;
    }
}
