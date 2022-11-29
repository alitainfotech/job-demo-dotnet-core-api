using Microsoft.AspNetCore.Mvc;
using JobApplicationApi.IServices;
using JobApplicationApi.Models;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore.StaticFiles;

namespace JobApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Candidate/GetAllCandidate")]
        public IEnumerable<Candidate> GetAllCandidate()
        {
            return _candidateService.GetCandidate();

        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Candidate/AddCandidate")]
        public Candidate AddCandidate(Candidate candidate)
        {
            return _candidateService.AddCandidate(candidate);
            //return null;
        }

        [HttpDelete]
        [Route("[action]")]
        [Route("api/Candidate/DeleteCandidate")]
        public Candidate DeleteCandidate(int id)
        {
            return _candidateService.DeleteCandidate(id);
            //return null;
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Candidate/uploadFile")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> uploadFile(IFormFile file, CancellationToken cancellationToken)
        {
            var result = await writefile(file);
            return Ok(result);
        }


        [HttpGet]
        [Route("[action]")]
        [Route("api/Candidate/DownloadFile")]
        public async Task<IActionResult> DownloadFile(string file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "upload\\files", file);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(path, out var ContentType))
            {
                ContentType = "application/octet-stream";

            }
            var bytes = await System.IO.File.ReadAllBytesAsync(path);

            return File(bytes, ContentType, Path.GetFileName(path));
        }

        private async Task<string> writefile(IFormFile file)
        {
            string fileName = "";

            try
            {
                var extenstion = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];

                fileName = DateTime.Now.Ticks + extenstion;
                var pathBuild = Path.Combine(Directory.GetCurrentDirectory(), "upload\\files");

                if (!Directory.Exists(pathBuild))
                {
                    Directory.CreateDirectory(pathBuild);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "upload\\files", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch
            {

            }

            return fileName;

        }




    }
}
