
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
            return _db.Files.ToList();
        }

        public async Task AddFileAsync(FileMetadata file)
        {
            _db.Files.Add(file);
            await _db.SaveChangesAsync();
        }
    }
}
