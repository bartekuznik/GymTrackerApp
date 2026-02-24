using AutoMapper;
using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;
using GymTrackerAPI.Models.Workout;
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
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutsRepository _workoutsRepository;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public WorkoutsController(IWorkoutsRepository workoutsRepository, IMapper mapper, IUserAccessor? userAccessor)
        {
            _workoutsRepository = workoutsRepository;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        // GET: api/Workouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutDto>>> GetWorkouts()
        {
            var userId = _userAccessor.GetUserId();
            var workouts = await _workoutsRepository.GetAllAsync(q => q.UserId == userId);
            var workoutsDtos = _mapper.Map<IEnumerable<WorkoutDto>>(workouts);
            return Ok(workoutsDtos);
        }

        // GET: api/Workouts
        [HttpGet("Preview")]
        public async Task<ActionResult<IEnumerable<WorkoutPreviewDto>>> GetWorkoutsWithPreview()
        {
            var userId = _userAccessor.GetUserId();
            var workouts = await _workoutsRepository.GetAllWorkkousWithPreviewAsync(userId);
            var workoutsDtos = _mapper.Map<IEnumerable<WorkoutPreviewDto>>(workouts);
            return Ok(workoutsDtos);
        }

        // GET: api/Workouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutDto>> GetWorkout(Guid id)
        {
            var userId = _userAccessor.GetUserId();
            var workout = await _workoutsRepository.GetWorkoutWithDetailsAsync(id, userId);

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
            var userId = _userAccessor.GetUserId();
            if (id != updateWorkoutDto.Id)
            {
                return BadRequest();
            }

            var workout = await _workoutsRepository.GetById(id, q => q.UserId == userId);

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
            var userId = _userAccessor.GetUserId();
            var workout = _mapper.Map<Workout>(createWorkoutDto);
            workout.UserId = userId;

            await _workoutsRepository.AddAsync(workout);

            return CreatedAtAction("GetWorkout", new { id = workout.Id }, workout);
        }

        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(Guid id)
        {
            var userId = _userAccessor.GetUserId();

            if (id == Guid.Empty)
            {
                return BadRequest();
            }


            var deleted = await _workoutsRepository.DeleteAsync(id, q => q.UserId == userId);

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
