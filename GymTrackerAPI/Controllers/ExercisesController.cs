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
using GymTrackerAPI.Models.Exercise;

namespace GymTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExercisesRepository _exercisesRepository;
        private readonly IMapper _mapper;

        public ExercisesController(IExercisesRepository exercisesRepository, IMapper mapper)
        {
            _exercisesRepository = exercisesRepository;
            _mapper = mapper;
        }

        // GET: api/Exercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseDto>>> GetExercises()
        {
            var exercises = await _exercisesRepository.GetAllAsync();
            var exercisesDto = _mapper.Map<IEnumerable<ExerciseDto>>(exercises.Where(x => !x.IsDeleted)); //tylko te nie soft deleted
            return Ok(exercisesDto);
        }

        //Przed zdefiniowaniem ról admina potrzebujemy tylko listy

        //// GET: api/Exercises/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ExerciseDto>> GetExercise(Guid id)
        //{
        //    var exercise = await _exercisesRepository.GetById(id);

        //    if (exercise == null)
        //    {
        //        return NotFound();
        //    }

        //    var exerciseDto  = _mapper.Map<ExerciseDto>(exercise);

        //    return Ok(exerciseDto);
        //}

        //// PUT: api/Exercises/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutExercise(Guid id, Exercise exercise)
        //{
        //    if (id != exercise.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(exercise).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ExerciseExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Exercises
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Exercise>> PostExercise(Exercise exercise)
        //{
        //    _context.Exercises.Add(exercise);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetExercise", new { id = exercise.Id }, exercise);
        //}

        //// DELETE: api/Exercises/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteExercise(Guid id)
        //{
        //    var exercise = await _context.Exercises.FindAsync(id);
        //    if (exercise == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Exercises.Remove(exercise);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ExerciseExists(Guid id)
        //{
        //    return _context.Exercises.Any(e => e.Id == id);
        //}
    }
}
