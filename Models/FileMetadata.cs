namespace FileLab.Models
{
    public class FileMetadata
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadDate { get; set; }
        public string ContentType { get; set; }

    }
}
