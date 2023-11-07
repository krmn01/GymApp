using GymApp.Application.Interfaces.Persistence;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace GymApp.Persistence.Services
{
    public class QrService : IQrService
    {
        private byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        public byte[] GenerateGymPassQrCode(Guid gymPassId, DateTime validTill, DateTime startedOn)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            QRCodeData qrCodeData = qrGenerator.CreateQrCode($"Id:{gymPassId}\nStartedOn:{startedOn}\nValidTill:{validTill}", QRCodeGenerator.ECCLevel.Q);

            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return BitmapToBytes(qrCodeImage);
        }
      
    }
}
