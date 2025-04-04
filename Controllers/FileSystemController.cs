using FileLab.Data.Models;
using FileLab.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FileLab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileSystemController : ControllerBase
    {
        private readonly FileService _fileService;

        public FileSystemController(FileService fileService)
        {
            _fileService = fileService;
        }


        [HttpGet]
        public IActionResult GetAllFiles()
        {
            var files = _fileService.GetFiles();
            return Ok(files);
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            var fileMetadata = await _fileService.GetFileByIdAsync(id);
            if (fileMetadata == null)
                return NotFound();

            return File(fileMetadata.FileContent, "application/octet-stream", fileMetadata.FileName);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file, [FromForm] FileMetadata metadata)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is empty");

            await _fileService.SaveFileAsync(file, metadata);
            return Ok("File uploaded successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, string name)
        {
            await _fileService.RenameFile(id, name);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _fileService.DeleteFileAsync(id);
            return Ok();
        }

        [HttpDelete("deleteAll")]
        public async Task<IActionResult> DeleteAllFiles()
        {
            await _fileService.DeleteAllFilesAsync();
            return Ok("All files deleted successfully");
        }
    }
}
