using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.ApplicationUser.Queries.GetUsersData
{
    public record GetUsersDataQuery(Guid id) :IRequest<ApplicationUserDTO>;
}
