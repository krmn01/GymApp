using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Application.Features.GymPass.Queries.GetGymPass
{
    public class GymPassDTO
    {
        public Guid Id {  get; set; }
        public DateTime ValidTill {  get; set; }
        public DateTime StartedOn { get; set; }

        public byte[] QrCode { get; set; }
    }
}
