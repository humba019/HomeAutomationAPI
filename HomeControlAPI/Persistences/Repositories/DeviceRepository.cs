using HomeControlAPI.Models;
using HomeControlAPI.Persistences.Contexts;
using HomeControlAPI.Persistences.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeControlAPI.Persistences.Repositories
{
    public class DeviceRepository : BaseRepository, IDeviceRepository
    {
        public DeviceRepository(DatabaseContext context) : base(context) { }

        public async Task AddAsync(Device device)
        {
            await _context.Device.AddAsync(device);
        }

        public async Task<Device> FindByIdAsync(int id)
        {
            return await _context.Device.FindAsync(id);
        }

        public async Task<Device> FindByPortAsync(int port)
        {
            Device portDevice = new Device();

            foreach (Device device in await _context.Device.ToListAsync())
            {
                if (device.Port.Equals(port))
                {
                    portDevice = device;
                }
            }

            return await _context.Device.FindAsync(portDevice.Id);
        }

        public async Task<IEnumerable<Device>> ListAsync()
        {
            return await _context.Device.ToListAsync();
        }

        public void Remove(Device device)
        {
            _context.Device.Remove(device);
        }

        public void Update(Device device)
        {
            _context.Device.Update(device);
        }
    }
}
