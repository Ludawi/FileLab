using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileLab.Data.Models
{
    public class FileMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string FileName { get; set; }
        public required byte[] FileContent { get; set; }
        public required DateTime UploadDate { get; set; }
        public required DateTime LastChanged { get; set; }
    }
}
