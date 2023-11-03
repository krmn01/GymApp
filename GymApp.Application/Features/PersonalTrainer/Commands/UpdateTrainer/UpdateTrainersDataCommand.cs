using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.PersonalTrainer.Commands.UpdateTrainer
{
    public class UpdateTrainersDataCommand :IRequest<Unit>
    {
        public Guid TrainerGuid { get; set; }
        public UpdateTrainerDTO UpdatedTrainer {  get; set; }
    }
}
