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

        [HttpPost]
        public async Task<IActionResult> Upload(FileMetadata file)
        {
            await _fileService.AddFileAsync(file);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FileMetadata file)
        {
            await _fileService.UpdateFileAsync(id, file);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _fileService.DeleteFileAsync(id);
            return Ok();
        }
    }
}
