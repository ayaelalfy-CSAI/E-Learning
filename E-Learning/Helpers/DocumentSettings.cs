namespace E_Learning.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string subfolder)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", subfolder);

            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }


            string FileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            string FilePath = Path.Combine(FolderPath, FileName);

            using var FileStream = new FileStream(FilePath, FileMode.Create);

            file.CopyTo(FileStream);

            return FileName;

        }

        public static string UploadVideo(IFormFile videoFile)
        {
            return UploadFile(videoFile, "videos"); // Store in "wwwroot/videos" directory
        }
    }
}
