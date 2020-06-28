using HomeControlAPI.Models;
using HomeControlAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeControlAPI.Services.Interfaces
{
    public interface IDeviceService
    {
        Task<IEnumerable<Device>> ListAsync();
        Task<DeviceResponse> SaveAsync(Device device);
        Task<DeviceResponse> UpdateAsync(int id, Device device);
        Task<DeviceResponse> DeleteAsync(int id);
    }
}
