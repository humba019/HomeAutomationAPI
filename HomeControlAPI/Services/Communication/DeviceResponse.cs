using HomeControlAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeControlAPI.Services.Communication
{
    public class DeviceResponse : BaseResponse
    {
        public Device Device { get; private set; }
        public DeviceResponse(bool success, string message, Device device) : base(success, message)
        {
            Device = device;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="advertencia">Saved advertencia.</param>
        /// <returns>Response.</returns>
        public DeviceResponse(Device device) : this(true, string.Empty, device)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public DeviceResponse(string message) : this(false, message, null)
        { }
    }
}
