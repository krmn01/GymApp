﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymPass.Requests.GetGymPass
{
    public class GetGymPassCommand :IRequest<GymPassDTO>
    {
        public Guid ProfileId { get; set; }
    }
}