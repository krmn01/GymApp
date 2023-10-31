using GymApp.Application.Features.PersonalTrainer;
using GymApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.PersonalTrainer.GetAllPersonalTrainers
{
    public class GetAllPersonalTrainersQuery :IRequest<List<PersonalTrainerDTO>>
    {
    }
}
