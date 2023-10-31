using GymApp.Application.Features.TrainingGoal;
using GymApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Interfaces.Persistence
{
    public interface ITrainingGoalService
    {
        Task<Response<List<TrainingGoalDTO>>> GetTrainingGoalsById(Guid id);
        Task<Response<string>> AddTrainingGoal(Guid id, string content);
        Task<Response<string>> ToggleTrainingGoal(Guid goalId, Guid profileId);
        Task<Response<string>> DeleteTrainingGoal(Guid goalId, Guid profileId);
    }
}
