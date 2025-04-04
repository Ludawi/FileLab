
using FileLab.Data.Contexts;
using FileLab.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<FileMetadata?> GetFileByIdAsync(int id)
        {
            return await _db.Files.FindAsync(id);
        }

        public async Task SaveFileAsync(IFormFile file, FileMetadata metadata)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                metadata.FileContent = memoryStream.ToArray();
            }

            metadata.FileName = file.FileName;
            metadata.UploadDate = DateTime.UtcNow;
            metadata.LastChanged = DateTime.UtcNow;
            _db.Files.Add(metadata);
            await _db.SaveChangesAsync();
        }


        public async Task RenameFile(int id, string filename)
        {
            var existingFile = _db.Files.FirstOrDefault(f => f.Id == id);
            if (existingFile != null)
            {
                existingFile.FileName = filename;
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

        public async Task DeleteAllFilesAsync()
        {
            var allFiles = _db.Files.ToList();
            _db.Files.RemoveRange(allFiles);
            await _db.SaveChangesAsync();
        }
    }
}
