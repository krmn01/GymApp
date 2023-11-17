using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.PersonalTrainer.Commands.DeleteTrainer
{
    public class DeleteTrainerCommand :IRequest<Unit>
    {
        public Guid TrainerId { get; set; }
    }
}
