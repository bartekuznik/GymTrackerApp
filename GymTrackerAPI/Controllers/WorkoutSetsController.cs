using AutoMapper;
using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;
using GymTrackerAPI.Models.WorkoutSet;
using GymTrackerAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTrackerAPI.Controllers
{
    [Authorize]
    [Route("api/workoutexercises/{exerciseId}/sets")]
    [ApiController]
    public class WorkoutSetsController : ControllerBase
    {
        private readonly IWorkoutSetsRepository _workoutSetsRepository;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public WorkoutSetsController(IWorkoutSetsRepository workoutSetsRepository, IMapper mapper, IUserAccessor? userAccessor)
        {
            _workoutSetsRepository = workoutSetsRepository;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        // GET: api/WorkoutSets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutSetDto>>> GetWorkoutSetsByExercise(Guid exerciseId)
        {
            var userId = _userAccessor.GetUserId();
            var workoutSets = await _workoutSetsRepository.GetSetsByExerciseIdAsync(exerciseId, userId);
            var workoutSetsDto = _mapper.Map<IEnumerable<WorkoutSetDto>>(workoutSets);
            return Ok(workoutSetsDto);
        }


        // GET: api/WorkoutSets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutSetDto>> GetWorkoutSet(Guid id, Guid exerciseId)
        {
            var userId = _userAccessor.GetUserId();

            var workoutSet = await _workoutSetsRepository.GetById(id, q => q.WorkoutExercise.Workout.UserId == userId);

            if (workoutSet == null || workoutSet.WorkoutExerciseId != exerciseId)
            {
                return NotFound();
            }

            var workoutSetDto = _mapper.Map<WorkoutSetDto>(workoutSet);

            return Ok(workoutSetDto);
        }

        // PUT: api/WorkoutSets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkoutSet(Guid exerciseId, Guid id, UpdateWorkoutSetDto updateWorkoutSetDto)
        {
            var userId = _userAccessor.GetUserId();

            if (id != updateWorkoutSetDto.Id)
            {
                return BadRequest();
            }

            var workoutSet = await _workoutSetsRepository.GetById(id, q => q.WorkoutExercise.Workout.UserId == userId);

            if (workoutSet == null || workoutSet.WorkoutExerciseId != exerciseId)
            {
                return NotFound();
            }

            _mapper.Map(updateWorkoutSetDto, workoutSet);

            await _workoutSetsRepository.UpdateAsync(workoutSet);

            return NoContent();
        }

        // POST: api/WorkoutSets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkoutSetDto>> PostWorkoutSet(CreateWorkoutSetDto createWorkoutSetDto, Guid exerciseId)
        {

            var workoutSet = _mapper.Map<WorkoutSet>(createWorkoutSetDto);
            workoutSet.WorkoutExerciseId = exerciseId;
            await _workoutSetsRepository.AddAsync(workoutSet);

            return CreatedAtAction("GetWorkoutSet", new { exerciseId = exerciseId, id = workoutSet.Id }, workoutSet);
        }

        // DELETE: api/WorkoutSets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutSet(Guid exerciseId, Guid id)
        {

            var userId = _userAccessor.GetUserId();

            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var workoutSet = await _workoutSetsRepository.GetById(id, q => q.WorkoutExercise.Workout.UserId == userId);

            if (workoutSet == null || workoutSet.WorkoutExerciseId != exerciseId)
            {
                return NotFound();
            }

            await _workoutSetsRepository.DeleteAsync(id, q => q.WorkoutExercise.Workout.UserId == userId);

            return NoContent();
        }
    }
}
