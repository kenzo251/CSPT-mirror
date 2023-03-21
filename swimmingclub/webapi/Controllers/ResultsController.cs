﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Results;
using webapi.Repositories;

namespace webapi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase {
        private readonly IResultRepository _repo;

        public ResultsController(IResultRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetResultModel>>> GetResult() {
            return await _repo.GetResults();
        }

        [HttpGet("{raceid}/{swimmerid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetResultModel>> GetResult(Guid raceid, Guid swimmerid) {
            GetResultModel result =  await _repo.GetResult(raceid,swimmerid);
            return result==null?new StatusCodeResult(StatusCodes.Status404NotFound):result;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GetResultModel> PostResult(PostResultModel Result) {
            var Id = new Guid("12345678-1234-1234-1234-1234567890ab");
            return CreatedAtAction(nameof(PostResult), new { id = Id }, Result);
        }
    }
}
