using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymTrackerAPI.Data;
using GymTrackerAPI.Repositories;
using AutoMapper;
using GymTrackerAPI.Models.NutritionLog;
using GymTrackerAPI.Contracts;

namespace GymTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionLogsController : ControllerBase
    {
        private readonly INutritionLogsRepository _nutritionLogsRepository;
        private readonly IMapper _mapper;

        public NutritionLogsController(INutritionLogsRepository nutritionLogsRepository, IMapper mapper)
        {
            _nutritionLogsRepository = nutritionLogsRepository;
            _mapper = mapper;
        }

        // GET: api/NutritionLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NutritionLogDto>>> GetNutritionLogs()
        {
            var nutritionLog = await _nutritionLogsRepository.GetAllAsync();
            var nutritionLogDto = _mapper.Map<IEnumerable<NutritionLogDto>>(nutritionLog);
            return Ok(nutritionLogDto);
        }

        // GET: api/NutritionLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NutritionLogDto>> GetNutritionLog(Guid id)
        {
            var nutritionLog = await _nutritionLogsRepository.GetById(id);

            if (nutritionLog == null)
            {
                return NotFound();
            }

            var nutritionLogDto = _mapper.Map<NutritionLogDto>(nutritionLog);

            return Ok(nutritionLogDto);
        }

        // PUT: api/NutritionLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNutritionLog(Guid id, UpdateNutritionLogDto updateNutritionLogDto)
        {
            if (id != updateNutritionLogDto.Id)
            {
                return BadRequest();
            }

            var nutritionLog = await _nutritionLogsRepository.GetById(id);

            if (nutritionLog == null)
            {
                return NotFound();
            }

            _mapper.Map(updateNutritionLogDto, nutritionLog);
           
            await _nutritionLogsRepository.UpdateAsync(nutritionLog);

            return NoContent();
        }

        // POST: api/NutritionLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateNutritionLogDto>> PostNutritionLog(CreateNutritionLogDto createNutritionLogDto)
        {
            //var userId = User.GetUserId(); // pobrane z tokena JWT
            var tempUserId = Guid.Parse("42a01733-e4b8-46c0-95c0-cd178ca92d1c"); //userId Jan Kowalski                                                                      //
            var nutritionLog = _mapper.Map<NutritionLog>(createNutritionLogDto);

            nutritionLog.UserId = tempUserId;
            await _nutritionLogsRepository.AddAsync(nutritionLog);

            return CreatedAtAction("GetNutritionLog", new { id = nutritionLog.Id }, nutritionLog);
        }

        // DELETE: api/NutritionLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNutritionLog(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var deleted = await _nutritionLogsRepository.DeleteAsync(id);

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
