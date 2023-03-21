﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Workouts;
using webapi.Repositories;

namespace webapi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase {
        private readonly IWorkoutRepository _repo;

        public WorkoutsController(IWorkoutRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetWorkoutModel>>> GetWorkout() {
            return await _repo.GetWorkouts();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetWorkoutModel>> GetWorkout(Guid id) {
            GetWorkoutModel workout = await _repo.GetWorkout(id);
            return workout == null?new StatusCodeResult(StatusCodes.Status404NotFound):workout;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GetWorkoutModel> PostWorkout(PostWorkoutModel Workout) {
            var Id = new Guid("12345678-1234-1234-1234-1234567890ab");
            return CreatedAtAction(nameof(PostWorkout), new { id = Id }, Workout);
        }
    }
}
