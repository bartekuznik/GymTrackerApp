using AutoMapper;
using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;
using GymTrackerAPI.Models.WaterLog;
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
    public class WaterLogsController : ControllerBase
    {
        private readonly IWaterLogsRepository _waterLogsRepository;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public WaterLogsController(IWaterLogsRepository waterLogsRepository, IMapper mapper, IUserAccessor? userAccessor)
        {
            _waterLogsRepository = waterLogsRepository;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        // GET: api/WaterLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterLogDto>>> GetWaterLogs()
        {
            var userId = _userAccessor.GetUserId();
            var waterLog = await _waterLogsRepository.GetAllAsync(q => q.UserId == userId);
            var waterLogDto = _mapper.Map<IEnumerable<WaterLogDto>>(waterLog);
            return Ok(waterLogDto);
        }

        // GET: api/WaterLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterLogDto>> GetWaterLog(Guid id)
        {
            var userId = _userAccessor.GetUserId();
            var waterLog = await _waterLogsRepository.GetById(id, q => q.UserId == userId);

            if (waterLog == null)
            {
                return NotFound();
            }

            var waterLogDto = _mapper.Map<WaterLogDto>(waterLog);

            return Ok(waterLogDto);
        }

        // PUT: api/WaterLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaterLog(Guid id, UpdateWaterLogDto updateWaterLogDto)
        {
            var userId = _userAccessor.GetUserId();

            if (id != updateWaterLogDto.Id)
            {
                return BadRequest();
            }

            var waterLog = await _waterLogsRepository.GetById(id, q => q.UserId == userId);

            if (waterLog == null)
            {
                return NotFound();
            }

            _mapper.Map(updateWaterLogDto, waterLog);

            await _waterLogsRepository.UpdateAsync(waterLog);

            return NoContent();
        }

        // POST: api/WaterLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateWaterLogDto>> PostWaterLog(CreateWaterLogDto createWaterLogDto)
        {
            
            var userId = _userAccessor.GetUserId();
            var waterLog = _mapper.Map<WaterLog>(createWaterLogDto);

            waterLog.UserId = userId;

            await _waterLogsRepository.AddAsync(waterLog);

            return CreatedAtAction("GetWaterLog", new { id = waterLog.Id }, waterLog);
        }

        // DELETE: api/WaterLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWaterLog(Guid id)
        {
            var userId = _userAccessor.GetUserId();

            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var deleted = await _waterLogsRepository.DeleteAsync(id, q => q.UserId == userId);

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
