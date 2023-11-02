using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.PersonalTrainer.Commands.CreateNewTrainer
{
    public class CreateNewTrainerCommand :IRequest<Guid>
    {
        public NewTrainerDTO NewTrainer {  get; set; }
    }
}
