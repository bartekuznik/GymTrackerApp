using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymTrackerAPI.Data;
using GymTrackerAPI.Contracts;
using AutoMapper;
using GymTrackerAPI.Models.WorkoutExercise;

namespace GymTrackerAPI.Controllers
{
    [Route("api/workouts/{workoutId}/workoutexercises")]
    [ApiController]
    public class WorkoutExercisesController : ControllerBase
    {
        private readonly IWorkoutExercisesRepository _workoutExercisesRepository;
        private readonly IMapper _mapper;

        public WorkoutExercisesController(IWorkoutExercisesRepository workoutExercisesRepository, IMapper mapper)
        {
            _workoutExercisesRepository = workoutExercisesRepository;
            _mapper = mapper;
        }

        // GET: api/WorkoutExercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutExerciseDto>>> GetWorkoutExercises(Guid workoutId)
        {
            var workoutExercises = await _workoutExercisesRepository.GetWorkoutExerciseByWorkoutIdWithPreviewAsync(workoutId);
            var workoutExercisesDto = _mapper.Map<IEnumerable<WorkoutExerciseDto>>(workoutExercises);
            return Ok(workoutExercisesDto);

        }

        // GET: api/WorkoutExercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutExercise>> GetWorkoutExercise(Guid id, Guid workoutId)
        {
            var workoutExercise = await _workoutExercisesRepository.GetById(id);

            if (workoutExercise == null || workoutExercise.WorkoutId != workoutId)
            {
                return NotFound();
            }

            var workoutExerciseDto = _mapper.Map<WorkoutExerciseDto>(workoutExercise);

            return Ok(workoutExerciseDto);
        }

        // PUT: api/WorkoutExercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkoutExercise(Guid workoutId, Guid id, UpdateWorkoutExerciseDto updateWorkoutExerciseDto)
        {
            if (id != updateWorkoutExerciseDto.Id)
            {
                return BadRequest();
            }

            var workutExercise = await _workoutExercisesRepository.GetById(id);

            if (workutExercise == null || workutExercise.WorkoutId != workoutId) 
            {
                return NotFound();
            }

            _mapper.Map(updateWorkoutExerciseDto, workutExercise);

            await _workoutExercisesRepository.UpdateAsync(workutExercise);

            return NoContent();
        }

        // POST: api/WorkoutExercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkoutExercise>> PostWorkoutExercise(Guid workoutId, CreateWorkoutExerciseDto createWorkoutExerciseDto)
        {
            var workoutExercise = _mapper.Map<WorkoutExercise>(createWorkoutExerciseDto);
            workoutExercise.WorkoutId = workoutId;

            return CreatedAtAction("GetWorkoutExercise", new { workoutId = workoutId, id = workoutExercise.Id }, workoutExercise);
        }

        // DELETE: api/WorkoutExercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutExercise(Guid workoutId, Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var workoutExercise = await _workoutExercisesRepository.GetById(id);

            if (workoutExercise == null || workoutExercise.WorkoutId != workoutId)
            {
                return NotFound();
            }

            await _workoutExercisesRepository.DeleteAsync(id);

            return NoContent();
        }


    }
}
