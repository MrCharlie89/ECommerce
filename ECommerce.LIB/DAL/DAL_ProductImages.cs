using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.VDOAP.CProef.ECommerce.LIB.DAL
{
    public static class DAL_ProductImages
    {
        private static Account MyImageAccount = new Account(
            "du3gy4w8e",
            "318466721753827",
            "L_704YRJFSBKIm3JGu35j7CwDy4");

        public static string UploadImage(Entities.ProductImages image, string ProductName)
        {
            Cloudinary cloudinary = new Cloudinary(MyImageAccount);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(image.FileLocation),
                PublicId = $"ProductName_{ProductName}_ID{image.ProductID}_Ord{image.ImageOrder}",
                Overwrite = true,
                Folder = $"Products/{ProductName}{image.ProductID}"
            };
            var uploadResult = cloudinary.Upload(uploadParams);

            string url = uploadResult.Uri.ToString();

            return url;
        }

    }
}
