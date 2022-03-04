using Core.DTO;
using Core.Interfaces.CustomServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;
        private readonly ILogger<PlaylistController> _logger;
        public PlaylistController(IPlaylistService playlistService, ILogger<PlaylistController> logger)
        {
            _playlistService = playlistService;
            _logger = logger;
        }
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public async Task<ActionResult<IEnumerable<PlaylistDTO>>> Get()
        {
            return Ok(await _playlistService.Get());
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PlaylistDTO>> Get(int id)
        {
            var playlist = await _playlistService.GetPlaylistById(id);
            _logger.LogInformation($"Got a playlist with id {id}");
            return playlist;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PlaylistDTO playlist)
        {
            await _playlistService.Create(playlist);
            _logger.LogInformation("Playlist was successfully created!");
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PlaylistDTO playlist)
        {
            await _playlistService.Edit(playlist);
            _logger.LogInformation("Playlist was successfully updated!");
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _playlistService.Delete(id);
            _logger.LogInformation($"Successfully delete playlist with id {id}");
            return Ok();
        }
    }
}