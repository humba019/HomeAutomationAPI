using HomeControlAPI.Models;
using HomeControlAPI.Persistences.Repositories.Interfaces;
using HomeControlAPI.Services.Communication;
using HomeControlAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeControlAPI.Services
{
    public class DeviceService : IDeviceService
    {
        public readonly IDeviceRepository _deviceRepository;
        public readonly IUnitOfWork _unitOfWork;

        public DeviceService(IDeviceRepository deviceRepository, IUnitOfWork unitOfWork)
        {
            this._deviceRepository = deviceRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task<DeviceResponse> DeleteAsync(int id)
        {
            var exist = await _deviceRepository.FindByIdAsync(id);

            if (exist == null)
                return new DeviceResponse($"Device by id { id } dont exist");

            try
            {
                _deviceRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return new DeviceResponse(exist);
            }
            catch (Exception e)
            {
                return new DeviceResponse($"An error occurred when deleting the device: { e.Message }");
            }

        }

        public async Task<IEnumerable<Device>> ListAsync()
        {
            return await _deviceRepository.ListAsync();
        }

        public async Task<DeviceResponse> SaveAsync(Device device)
        {
            try
            {
                Device deviceObj = await _deviceRepository.FindByPortAsync(device.Port);
                if (deviceObj != null)
                {
                    return new DeviceResponse($"Device by port { device.Port } already exist");
                }

                await _deviceRepository.AddAsync(device);
                await _unitOfWork.CompleteAsync();

                return new DeviceResponse(device);
            }
            catch (Exception e)
            {
                return new DeviceResponse($"An error occurred when saving the device: {e.Message}");
            }
        }

        public async Task<DeviceResponse> UpdateAsync(int id, Device device)
        {
            var exist = await _deviceRepository.FindByIdAsync(id);

            if (exist == null) {
                return new DeviceResponse("Device not found");
            }

            exist.Port = device.Port;
            exist.Status = device.Status;

            try
            {
                _deviceRepository.Update(exist);
                await _unitOfWork.CompleteAsync();

                return new DeviceResponse(exist);
            }
            catch (Exception e)
            {
                return new DeviceResponse($"An error occurred when updating the device: { e.Message }");
            }
        }
    }
}
