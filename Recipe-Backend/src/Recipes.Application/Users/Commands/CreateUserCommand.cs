using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Recipes.Application.Users.Commands;



public record CreateUserCommand(string Email, string Password) : IRequest<Guid>;
