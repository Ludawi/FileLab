
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
                FileName = "Testfile"
            };
            _db.Files.Add(file);
            await _db.SaveChangesAsync();
        }
    }
}
