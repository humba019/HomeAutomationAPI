using HomeControlAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeControlAPI.Persistences.Repositories.Interfaces
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> ListAsync();
        Task AddAsync(Device device);
        Task<Device> FindByIdAsync(int id);
        Task<Device> FindByPortAsync(int port);
        void Update(Device device);
        void Remove(Device device);
    }
}
