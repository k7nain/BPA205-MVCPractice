namespace Bilet_Practice_.Utilities.Extensions
{
    public static class ImageUploadsExtensions
    {
        public static  string SaveImage(this IFormFile formFile,IWebHostEnvironment environment , string folder)
        {
           string path = Path.Combine(environment.WebRootPath, folder);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Guid.NewGuid().ToString() + formFile.FileName;
            string fullPath = Path.Combine(path, fileName);
            
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                 formFile.CopyToAsync(stream);
            }
            return fileName;
        }

        public static string DeleteImage(this string formURL, IWebHostEnvironment environment, string folder)
        {
            string path = Path.Combine(environment.WebRootPath, folder);
            string fullPath = Path.Combine(path, formURL);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            return fullPath;
        }
    }
}
