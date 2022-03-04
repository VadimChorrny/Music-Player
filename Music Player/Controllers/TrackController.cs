using Core.DTO;
using Core.Interfaces;
using Core.Interfaces.CustomServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Music_Player.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ITrackService trackService;
        public TrackController(ITrackService trackService)
        {
            this.trackService = trackService;
        }
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public async Task<IEnumerable<TrackDTO>> Get() 
        {
            return await trackService.Get();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TrackDTO>> Get(int id)
        {
            return await trackService.GetTrackById(id);
        }
        [HttpPost]
        public ActionResult Create(TrackDTO track)
        {
            if (track == null) return BadRequest();
            trackService.Create(track);
            return Ok("Successfully created new track!");
        }
        [HttpPut]
        public ActionResult Edit(TrackDTO track)
        {
            if(track == null) return BadRequest();
            trackService.Edit(track);
            return Ok("Successfully updated selected track!");
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            if(id == 0) return BadRequest();
            trackService.Delete(id);
            return Ok("Successfully deleted selected track!");
        }
    }
}
