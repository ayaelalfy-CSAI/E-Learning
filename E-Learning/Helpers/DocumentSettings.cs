namespace E_Learning.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");

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

    }
}
