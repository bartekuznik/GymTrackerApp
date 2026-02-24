using AutoMapper;
using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;
using GymTrackerAPI.Models.NutritionLog;
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
    public class NutritionLogsController : ControllerBase
    {
        private readonly INutritionLogsRepository _nutritionLogsRepository;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public NutritionLogsController(INutritionLogsRepository nutritionLogsRepository, IMapper mapper, IUserAccessor? userAccessor)
        {
            _nutritionLogsRepository = nutritionLogsRepository;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        // GET: api/NutritionLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NutritionLogDto>>> GetNutritionLogs()
        {
            var userId = _userAccessor.GetUserId();
            var nutritionLog = await _nutritionLogsRepository.GetAllAsync(q => q.UserId == userId);
            var nutritionLogDto = _mapper.Map<IEnumerable<NutritionLogDto>>(nutritionLog);
            return Ok(nutritionLogDto);
        }

        // GET: api/NutritionLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NutritionLogDto>> GetNutritionLog(Guid id)
        {
            var userId = _userAccessor.GetUserId();
            var nutritionLog = await _nutritionLogsRepository.GetById(id, q => q.UserId == userId);

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
            var userId = _userAccessor.GetUserId();
            if (id != updateNutritionLogDto.Id)
            {
                return BadRequest();
            }

            var nutritionLog = await _nutritionLogsRepository.GetById(id, q => q.UserId == userId);

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
            
            var userId = _userAccessor.GetUserId();                                                                     //
            var nutritionLog = _mapper.Map<NutritionLog>(createNutritionLogDto);

            nutritionLog.UserId = userId;
            await _nutritionLogsRepository.AddAsync(nutritionLog);

            return CreatedAtAction("GetNutritionLog", new { id = nutritionLog.Id }, nutritionLog);
        }

        // DELETE: api/NutritionLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNutritionLog(Guid id)
        {
            var userId = _userAccessor.GetUserId();

            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var deleted = await _nutritionLogsRepository.DeleteAsync(id, q => q.UserId == userId);

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
