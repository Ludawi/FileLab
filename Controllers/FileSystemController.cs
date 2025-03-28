using FileLab.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileLab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileSystemController : ControllerBase
    {
        public FileSystemController()
        {
        }


        [HttpGet]
        public IActionResult Get(int id)
        {
            //FileService.GetFiles();

            return Ok();
        }

        [HttpPost]
        public IActionResult Upload()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
