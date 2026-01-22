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
using GymTrackerAPI.Models.WaterLog;

namespace GymTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterLogsController : ControllerBase
    {
        private readonly IWaterLogsRepository _waterLogsRepository;
        private readonly IMapper _mapper;

        public WaterLogsController(IWaterLogsRepository waterLogsRepository, IMapper mapper)
        {
            _waterLogsRepository = waterLogsRepository;
            _mapper = mapper;
        }

        // GET: api/WaterLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterLogDto>>> GetWaterLogs()
        {
            var waterLog = await _waterLogsRepository.GetAllAsync();
            var waterLogDto = _mapper.Map<IEnumerable<WaterLogDto>>(waterLog);
            return Ok(waterLogDto);
        }

        // GET: api/WaterLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaterLogDto>> GetWaterLog(Guid id)
        {

            var waterLog = await _waterLogsRepository.GetById(id);

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
            if (id != updateWaterLogDto.Id)
            {
                return BadRequest();
            }

            var waterLog = await _waterLogsRepository.GetById(id);

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
            //var userId = User.GetUserId(); // pobrane z tokena JWT
            var tempUserId = Guid.Parse("42a01733-e4b8-46c0-95c0-cd178ca92d1c"); //userId Jan Kowalski
            var waterLog = _mapper.Map<WaterLog>(createWaterLogDto);

            waterLog.UserId = tempUserId;

            await _waterLogsRepository.AddAsync(waterLog);

            return CreatedAtAction("GetWaterLog", new { id = waterLog.Id }, waterLog);
        }

        // DELETE: api/WaterLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWaterLog(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var deleted = await _waterLogsRepository.DeleteAsync(id);

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
