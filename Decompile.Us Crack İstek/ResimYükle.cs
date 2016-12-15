using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Decompile.Us_Crack_İstek
{
    internal class ResimYükle
    {
        public string Yükle(string resimyolu)
        {
            Account account = new Account("duj1m9euv", "366682913616939", "sIZ_S9Zs_C00uRgAdBrUmr_aHHE");
            Cloudinary cloudinary = new Cloudinary(account);
            ImageUploadParams parameters = new ImageUploadParams
            {
                File = new FileDescription(resimyolu)
            };
            ImageUploadResult imageUploadResult = cloudinary.Upload(parameters);
            return cloudinary.Api.UrlImgUp.BuildUrl(string.Format("{0}.{1}", imageUploadResult.PublicId, imageUploadResult.Format));
        }
    }
}