using AutoMapper;
using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;
using GymTrackerAPI.Models.BodyMeasurementLog;
using GymTrackerAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GymTrackerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BodyMeasurementLogsController : ControllerBase
    {
        private readonly IBodyMeasurementLogsRepository _bodyMeasurementLogsRepository;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public BodyMeasurementLogsController(IBodyMeasurementLogsRepository bodyMeasurementLogsRepository, IMapper mapper, IUserAccessor? userAccessor)
        {
            _bodyMeasurementLogsRepository = bodyMeasurementLogsRepository;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        // GET: api/BodyMeasurementLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyMeasurementLogDto>>> GetBodyMeasurementLogs()
        {
            var userId = _userAccessor.GetUserId();
            var bodyMeasurementLog = await _bodyMeasurementLogsRepository.GetAllAsync(q => q.UserId == userId);
            var bodyMeasurementLogDto = _mapper.Map<IEnumerable<BodyMeasurementLogDto>>(bodyMeasurementLog);
            return Ok(bodyMeasurementLogDto);
        }

        // GET: api/BodyMeasurementLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyMeasurementLogDto>> GetBodyMeasurementLog(Guid id)
        {
            var userId = _userAccessor.GetUserId();
            var bodyMeasurementLog = await _bodyMeasurementLogsRepository.GetById(id, q => q.UserId == userId);

            if (bodyMeasurementLog == null)
            {
                return NotFound();
            }

            var bodyMeasurementLogDto = _mapper.Map<BodyMeasurementLogDto>(bodyMeasurementLog);
            return Ok(bodyMeasurementLogDto);
        }

        // PUT: api/BodyMeasurementLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodyMeasurementLog(Guid id, UpdateBodyMeasurementLogDto updateBodyMeasurementLogDto)
        {
            var userId = _userAccessor.GetUserId();
            if (id != updateBodyMeasurementLogDto.Id)
            {
                return BadRequest();
            }

            var bodyMeasurementLog = await _bodyMeasurementLogsRepository.GetById(id, q => q.UserId == userId);

            if (bodyMeasurementLog == null) 
            {
                return NotFound();
            }

            _mapper.Map(updateBodyMeasurementLogDto, bodyMeasurementLog);

            
            await _bodyMeasurementLogsRepository.UpdateAsync(bodyMeasurementLog);
            

            return NoContent();
        }

        // POST: api/BodyMeasurementLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateBodyMeasurementLogDto>> PostBodyMeasurementLog(CreateBodyMeasurementLogDto createbodyMeasurementLog)
        {

            var userId = _userAccessor.GetUserId();
            var bodyMeasurementLog = _mapper.Map<BodyMeasurementLog>(createbodyMeasurementLog);
            bodyMeasurementLog.UserId = userId;

            await _bodyMeasurementLogsRepository.AddAsync(bodyMeasurementLog);

            return CreatedAtAction("GetBodyMeasurementLog", new { id = bodyMeasurementLog.Id }, bodyMeasurementLog);
        }

        // DELETE: api/BodyMeasurementLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodyMeasurementLog(Guid id)
        {
            var userId = _userAccessor.GetUserId();

            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var deleted = await _bodyMeasurementLogsRepository.DeleteAsync(id, q => q.UserId == userId);

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
