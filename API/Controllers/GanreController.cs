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
    public class GanreController : ControllerBase
    {
        private readonly IGanreService _ganreService;
        private readonly ILogger<GanreController> _logger;
        public GanreController(IGanreService ganreService, ILogger<GanreController> logger)
        {
            _ganreService = ganreService;
            _logger = logger;
        }
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public async Task<ActionResult<IEnumerable<GanreDTO>>> Get()
        {
            return Ok(await _ganreService.Get());
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GanreDTO>> Get(int id)
        {
            var track = await _ganreService.GetGanreById(id);
            _logger.LogInformation($"Got a ganre with id {id}");
            return track;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GanreDTO ganre)
        {
            await _ganreService.Create(ganre);
            _logger.LogInformation("Ganre was successfully created!");
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] GanreDTO ganre)
        {
            await _ganreService.Edit(ganre);
            _logger.LogInformation("Ganre was successfully updated!");
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _ganreService.Delete(id);
            _logger.LogInformation($"Successfully delete ganre with id {id}");
            return Ok();
        }
    }
}
