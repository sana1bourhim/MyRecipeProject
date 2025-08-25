using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain.Users;



namespace Recipes.Application.Users.Queries
{
   

    public record GetUserByIdQuery(Guid Id) : IRequest<User?>;

}
