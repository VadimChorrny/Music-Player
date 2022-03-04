using Core.DTO;
using Core.Interfaces.CustomServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ITrackService _trackService;
        private readonly ILogger<TrackController> _logger;
        public TrackController(ITrackService trackService,
            ILogger<TrackController> logger)
        {
            _trackService = trackService;
            _logger = logger;
        }
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public async Task<ActionResult<IEnumerable<TrackDTO>>> Get()
        {
            return Ok(await _trackService.Get());
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TrackDTO>> Get(int id)
        {
            var track = await _trackService.GetTrackById(id);
            _logger.LogInformation($"Got a track with id {id}");
            return track;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TrackDTO track)
        {
            await _trackService.Create(track);
            _logger.LogInformation("Track was successfully created!");
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] TrackDTO track)
        {
            await _trackService.Edit(track);
            _logger.LogInformation("Track was successfully updated!");
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _trackService.Delete(id);
            _logger.LogInformation($"Successfully delete track with id {id}");
            return Ok();
        }

    }
}
