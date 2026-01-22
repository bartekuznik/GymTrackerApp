using AutoMapper;
using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;
using GymTrackerAPI.Models.BodyMeasurementLog;
using GymTrackerAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyMeasurementLogsController : ControllerBase
    {
        private readonly IBodyMeasurementLogsRepository _bodyMeasurementLogsRepository;
        private readonly IMapper _mapper;

        public BodyMeasurementLogsController(IBodyMeasurementLogsRepository bodyMeasurementLogsRepository, IMapper mapper)
        {
            _bodyMeasurementLogsRepository = bodyMeasurementLogsRepository;
            _mapper = mapper;
        }

        // GET: api/BodyMeasurementLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyMeasurementLogDto>>> GetBodyMeasurementLogs()
        {
            var bodyMeasurementLog = await _bodyMeasurementLogsRepository.GetAllAsync();
            var bodyMeasurementLogDto = _mapper.Map<IEnumerable<BodyMeasurementLogDto>>(bodyMeasurementLog);
            return Ok(bodyMeasurementLogDto);
        }

        // GET: api/BodyMeasurementLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyMeasurementLogDto>> GetBodyMeasurementLog(Guid id)
        {
            var bodyMeasurementLog = await _bodyMeasurementLogsRepository.GetById(id);

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
            if (id != updateBodyMeasurementLogDto.Id)
            {
                return BadRequest();
            }

            var bodyMeasurementLog = await _bodyMeasurementLogsRepository.GetById(id);

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
            //var userId = User.GetUserId(); // pobrane z tokena JWT
            var tempUserId = Guid.Parse("42a01733-e4b8-46c0-95c0-cd178ca92d1c"); //userId Jan Kowalski

            var bodyMeasurementLog = _mapper.Map<BodyMeasurementLog>(createbodyMeasurementLog);
            bodyMeasurementLog.UserId = tempUserId;

            await _bodyMeasurementLogsRepository.AddAsync(bodyMeasurementLog);

            return CreatedAtAction("GetBodyMeasurementLog", new { id = bodyMeasurementLog.Id }, bodyMeasurementLog);
        }

        // DELETE: api/BodyMeasurementLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodyMeasurementLog(Guid id)
        {

            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var deleted = await _bodyMeasurementLogsRepository.DeleteAsync(id);

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
