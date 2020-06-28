using AutoMapper;
using HomeControlAPI.Models;
using HomeControlAPI.Extensions;
using HomeControlAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HomeControlAPI.Controllers
{
    [Route("home/device")]
    public class DeviceController : Controller
    {
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;

        public DeviceController(IDeviceService deviceService, IMapper mapper)
        {
            _deviceService = deviceService;
            _mapper = mapper;
        }

        // GET: home/device
        [HttpGet]
        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            return await _deviceService.ListAsync();
        }

        // POST: home/device
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Device>> PostAsync([FromBody] Device resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await _deviceService.SaveAsync(resource);

            return Ok(result);

        }
        // PUT: home/device/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<Device>> PutAsync(int id, [FromBody] Device resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await _deviceService.UpdateAsync(id, resource);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);

        }

        // DELETE: home/device/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Device>> DeleteAsync(int id)
        {
            var result = await _deviceService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
