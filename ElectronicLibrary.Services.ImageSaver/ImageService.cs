using ElectronicLibrary.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ElectronicLibrary.Services
{
    public class ImageService: IImageService
    {
        private const string _TMPL = "base64,";
        public async Task<string> SaveImageAsync(string path, string base64string)
        {
            try
            {
                long Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
                string filename = $"{path}\\{Timestamp}.jpg";

                base64string = GetBaseString(base64string);

                byte[] tempBytes = Convert.FromBase64String(base64string);
                await File.WriteAllBytesAsync(filename, tempBytes);

                return filename;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        private string GetBaseString(string imageString)
        {
            int _index = imageString.IndexOf(_TMPL);
            return imageString.Substring(_index + 7);
        }
    }
}
