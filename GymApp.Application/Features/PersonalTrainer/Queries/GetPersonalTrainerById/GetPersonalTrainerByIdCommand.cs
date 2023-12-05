using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.PersonalTrainer.Queries.GetPersonalTrainerById
{
    public class GetPersonalTrainerByIdQuery :IRequest<PersonalTrainerDTO>
    {
        public Guid Id { get; set; }
    }
}
