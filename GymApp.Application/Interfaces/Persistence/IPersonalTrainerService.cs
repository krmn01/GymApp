using GymApp.Application.Features.PersonalTrainer;
using GymApp.Application.Features.PersonalTrainer.Commands.CreateNewTrainer;
using GymApp.Domain.Common;
using GymApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Interfaces.Persistence
{
    public interface IPersonalTrainerService
    {
        Task<Response<List<PersonalTrainerDTO>>> GetAllTrainers();
        Task<Response<PersonalTrainerDTO>> GetPersonalTrainerById(Guid id);
        Task<Response<string>> CreateNewTrainer(NewTrainerDTO newTrainer);
    }
}
