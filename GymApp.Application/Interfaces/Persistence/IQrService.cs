using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Interfaces.Persistence
{
    public interface IQrService
    {
        byte[] GenerateGymPassQrCode(Guid gymPassId,DateTime validTill, DateTime startedOn);
    }
}
