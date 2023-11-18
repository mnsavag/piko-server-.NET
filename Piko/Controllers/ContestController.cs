using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Piko.Contracts;
using Piko.Dto;
using Piko.Validators;
using static Piko.Dto.ContestDto;


namespace Piko.Controllers
{
    [Route("api/contest")]
    [ApiController]
    public class ContestController : ControllerBase
    {
        private readonly IContestService _contestService;

        public ContestController(IContestService contestService)
        {
            _contestService = contestService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContest(ContestCreateDto contestDto)
        {
            var result = await _contestService.CreateContest(contestDto);
            return Ok(result);
        }

        [HttpPatch("{id}/upload")]
        public async Task<IActionResult> UploadContestImages(int id, [FromForm] ContestUploadImagesDto contestDto)
        {
            var previewsIsValid = FileValidator.isValidImage(contestDto.PreviewFirst) &&
                FileValidator.isValidImage(contestDto.PreviewSecond);

            var optionsIsValid = true;
            foreach(var file in contestDto.Options)
            {
                optionsIsValid = optionsIsValid && FileValidator.isValidImage(file);
            }
            if (!(previewsIsValid && optionsIsValid))
            {
                throw new Exception("Available formats jpg/jpeg/png");
            }

            var result = await _contestService.UploadContestImages(id, contestDto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetContest(int id)
        {
            var result = _contestService.GetContest(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllAccessContest(string name = "")
        {
            var result = _contestService.GetAllAccessContest(name);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContest(int id)
        {
            var result = _contestService.DeleteContest(id);
            return Ok(result);
        }

        [HttpPatch("{id}/option/{option}/victory")]
        public async Task<IActionResult> UpdateOptionVictory(int id, int option)
        {
            var result = await _contestService.UpdateOptionVictory(id, option);
            return Ok(result);
        }

        [HttpGet("{id}/top-list")]
        public IActionResult GetOptionsTopList(int id)
        {
            var result = _contestService.GetOptionsTopList(id);
            return Ok(result);
        }
    }
}