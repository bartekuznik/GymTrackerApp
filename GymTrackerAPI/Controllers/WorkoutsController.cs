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
using GymTrackerAPI.Models.Workout;

namespace GymTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutsRepository _workoutsRepository;
        private readonly IMapper _mapper;

        public WorkoutsController(IWorkoutsRepository workoutsRepository, IMapper mapper)
        {
            _workoutsRepository = workoutsRepository;
            _mapper = mapper;
        }

        // GET: api/Workouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutDto>>> GetWorkouts()
        {
            var workouts = await _workoutsRepository.GetAllAsync();
            var workoutsDtos = _mapper.Map<IEnumerable<WorkoutDto>>(workouts);
            return Ok(workoutsDtos);
        }

        // GET: api/Workouts
        [HttpGet("Preview")]
        public async Task<ActionResult<IEnumerable<WorkoutPreviewDto>>> GetWorkoutsWithPreview()
        {
            var workouts = await _workoutsRepository.GetAllWorkkousWithPreviewAsync();
            var workoutsDtos = _mapper.Map<IEnumerable<WorkoutPreviewDto>>(workouts);
            return Ok(workoutsDtos);
        }

        // GET: api/Workouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutDto>> GetWorkout(Guid id)
        {
            var workout = await _workoutsRepository.GetWorkoutWithDetailsAsync(id);

            if (workout == null)
            {
                return NotFound();
            }

            var workoutDto = _mapper.Map<WorkoutDto>(workout);

            return Ok(workoutDto);
        }

        // PUT: api/Workouts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkout(Guid id, UpdateWorkoutDto updateWorkoutDto)
        {
            if (id != updateWorkoutDto.Id)
            {
                return BadRequest();
            }

            var workout = await _workoutsRepository.GetById(id);

            if (workout == null) 
            {
                return NotFound();
            }    

            _mapper.Map(updateWorkoutDto, workout);

            await _workoutsRepository.UpdateAsync(workout);

            return NoContent();
        }

        // POST: api/Workouts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Workout>> PostWorkout(CreateWorkoutDto createWorkoutDto)
        {
            //var userId = User.GetUserId(); // pobrane z tokena JWT
            var tempUserId = Guid.Parse("42a01733-e4b8-46c0-95c0-cd178ca92d1c"); //userId Jan Kowalski
            var workout = _mapper.Map<Workout>(createWorkoutDto);
            workout.UserId = tempUserId;

            await _workoutsRepository.AddAsync(workout);

            return CreatedAtAction("GetWorkout", new { id = workout.Id }, workout);
        }

        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }


            var deleted = await _workoutsRepository.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
            
        }


    }
}
