namespace Bilet_1_Practice_.Utilities.Extensions
{
    public static class ImageUploadExtensions
    {
        public static string SaveImage(this IFormFile formFile, IWebHostEnvironment environment, string folder)
        {
            string path = Path.Combine(environment.WebRootPath, folder);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName = Guid.NewGuid() + formFile.FileName;
            string fullPath = Path.Combine(path, fileName);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }

            return fileName;
        }

        public static string DeleteImage(this IFormFile fileURL, IWebHostEnvironment environment, string folder)
        {
            string path = Path.Combine(environment.WebRootPath, folder);
            string fileName = Guid.NewGuid() + fileURL.FileName;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            string fullPath = Path.Combine(path, fileName);

            return fileName;
        }
    }
}
