using GymApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Interfaces.Persistence
{
    public interface IGymPassService
    {
        Task<Response<string>> RenewAsync(Guid profileId, int days);
    }
}
