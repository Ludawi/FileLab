
using FileLab.Data.Contexts;
using FileLab.Data.Models;

namespace FileLab.Services
{
    public class FileService
    {
        private readonly FileDbContext _db;

        public FileService(FileDbContext db)
        {
            _db = db;
        }

        public List<FileMetadata> GetFiles()
        {
            return _db.Files.ToList() ?? new List<FileMetadata>();
        }

        public async Task AddFileAsync(FileMetadata file)
        {
            file = new FileMetadata
            {
                FileName = "file1",
                UploadDate = DateTime.UtcNow,
                LastChanged = DateTime.UtcNow
            };
            _db.Files.Add(file);
            await _db.SaveChangesAsync();
        }

        public async Task AddFilesAsync(List<FileMetadata> files)
        {
            _db.Files.AddRange(files);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateFileAsync(int id, FileMetadata file)
        {
            var existingFile = _db.Files.FirstOrDefault(f => f.Id == id);
            if (existingFile != null)
            {
                existingFile.FileName = file.FileName;
                // existingFile.FilePath = file.FilePath;
                // existingFile.FileSize = file.FileSize;
                existingFile.LastChanged = DateTime.UtcNow;
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteFileAsync(int id)
        {
            var file = _db.Files.FirstOrDefault(f => f.Id == id);
            if (file != null)
            {
                _db.Files.Remove(file);
                await _db.SaveChangesAsync();
            }
        }
    }
}
