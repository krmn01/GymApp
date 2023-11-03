using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.Class.Queries.GetUsersClasses
{
    public class GetUsersClassesQuery :IRequest<List<ClassDTO>>
    {
        public Guid ProfileId { get; set; }
    }

}
