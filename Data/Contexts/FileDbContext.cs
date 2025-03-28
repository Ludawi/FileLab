using FileLab.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FileLab.Data.Contexts
{
    public class FileDbContext : DbContext
    {
        public FileDbContext(DbContextOptions<FileDbContext> options) : base(options)
        {
        }

        public DbSet<FileMetadata> Files { get; set; }
    }
}
