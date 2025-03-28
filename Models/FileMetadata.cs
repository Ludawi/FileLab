using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileLab.Models
{
    public class FileMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }
        public required string FileName { get; set; }
        public required string FilePath { get; set; }
        public required long FileSize { get; set; }
        public required DateTime UploadDate { get; set; }

    }
}
