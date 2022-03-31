using System.Collections.Generic;
using apitest.Managers;
using apitest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apitest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesBasicController : ControllerBase
    {
        private static TitlesBasicManager _manager = new TitlesBasicManager();
        // GET: api/<ValuesController>
        [HttpGet("actors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<ActorView>> GetAllActors()
        {
            if (_manager.GetAllActorData() == null) return NoContent();
            return Ok(_manager.GetAllActorData());
        }

        [HttpGet("movies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<ActorView>> GetAllMovies()
        {
            if (_manager.GetAllMovieData() == null) return NoContent();
            return Ok(_manager.GetAllMovieData());
        }

        // GET api/<TitlesBasicController>/5
        [HttpGet("actor{name}")]
        public ActorView GetActor(string name)
        {
            return _manager.GetActorData(name);
        }


        [HttpGet("movie{name}")]
        public MovieView GetMovie(string name)
        {
            return _manager.GetMovieData(name);
        }

        // POST api/<TitlesBasicController>
        [HttpPost("actor")]
        public NameBasics Post([FromBody] NameBasics newActor)
        {
            return _manager.AddActor(newActor);
        }

        [HttpPost("movie")]
        public TitlesBasic Post([FromBody] TitlesBasic newMovie)
        {
            return _manager.AddMovie(newMovie);
        }

        // PUT api/<TitlesBasicController>/5
        [HttpPut("actor{name}")]
        public NameBasics Put(string name, [FromBody] NameBasics value)
        {
            return _manager.UpdateActor(name, value);
        }

        [HttpPut("movie{name}")]
        public TitlesBasic Put(string name, [FromBody] TitlesBasic value)
        {
            return _manager.UpdateMovie(name, value);
        }

        // DELETE api/<TitlesBasicController>/5
        [HttpDelete("actor{name}")]
        public void DeleteActor(string name)
        {
            _manager.DeleteActor(name);
        }

        [HttpDelete("movie{name}")]
        public void DeleteMovie(string name)
        {
            _manager.DeleteMovie(name);
        }
    }
}
