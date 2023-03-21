﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Races;
using webapi.Repositories;

namespace webapi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RacesController : ControllerBase {

        private readonly IRaceRepository _repo;

        public RacesController(IRaceRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetRaceModel>>> GetRace() {
            return await _repo.GetRaces();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetRaceModel>> GetRace(Guid id) {
            GetRaceModel race = await _repo.GetRace(id);
            return race == null ? new StatusCodeResult(StatusCodes.Status404NotFound) : race;
        }

        [HttpGet("results")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetRaceResultModel>>> GetRaceResults() {
            return await _repo.GetRaceResults();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GetRaceModel> PostRace(PostRaceModel Race) {
            Guid Id = new Guid("12345678-1234-1234-1234-1234567890ab");
            return CreatedAtAction(nameof(PostRace), new { id = Id }, Race);
        }
    }
}
