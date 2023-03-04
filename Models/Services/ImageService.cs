using Microsoft.AspNetCore.Hosting;

namespace Hotel.Models.Services
{
    public class ImageService
    {
        public async Task<string> UploadAsync(IFormFile image_file, IWebHostEnvironment webHostEnvironment)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(image_file.FileName);
            // wwwroot/images/apartments/FileName.jpg
            string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images/apartments", $"{fileNameWithoutExtension}.jpg");
            // copy the uploaded file to the wwwroot/images folder
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image_file.CopyToAsync(fileStream);
            }
            return fileNameWithoutExtension;
        }
    }
}
