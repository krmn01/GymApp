using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymEntry.Commands.AddGymEntry
{
    public class AddGymEntryCommand :IRequest<Guid>
    {
        public Guid profileId { get; set; }
        public int timeInMinutes { get; set; }
    }
}
