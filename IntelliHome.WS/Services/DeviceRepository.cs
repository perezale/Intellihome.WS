using IntelliHome.WS.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelliHome.WS.Services
{
    public class DeviceRepository
    {
        public List<Device> FindAll()
        {
            using(var context = new IntellihomeContext())
            {
                return context.Device.ToList();
            }
        }

        public Device FindById(int id)
        {
            using (var context = new IntellihomeContext())
            {
                return context.Device
                    .FirstOrDefault(d => d.Id.Equals(id));
            }
        }

        public Device FindByIdComplete(int id)
        {
            using (var context = new IntellihomeContext())
            {
                return context.Device                    
                    .Include("DeviceCapability")
                    .Include("DeviceCapability.Capability")
                    .FirstOrDefault(d => d.Id.Equals(id));
            }
        }

        public List<Device> FindByUser(int userId)
        {
            using (var context = new IntellihomeContext())
            {
                var userDevices = context.User
                    .Include("Device")
                    .Where(u => u.Id.Equals(userId))
                    .SelectMany(u => u.Device).ToList();

                return userDevices;
            }
        }
    }
}