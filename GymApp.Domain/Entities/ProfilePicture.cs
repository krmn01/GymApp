using GymApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Domain.Entities
{
    public class ProfilePicture :BaseEntity
    {
        public byte[] Picture { get; set; }
    }
}
