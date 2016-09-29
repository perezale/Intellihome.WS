using IntelliHome.WS.Models.Db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IntelliHome.WS.Services
{
  public class DeviceRepository
  {
    public List<Device> FindAll()
    {
      using (var context = new IntellihomeContext())
      {
        return context.Device
          .Include("DeviceCapability")
          .Include("DeviceCapability.Capability")
          .ToList();
      }
    }

    public Device FindById(int id)
    {
      using (var context = new IntellihomeContext())
      {
        return context.Device
            .Where(d => d.Id.Equals(id))
            .Include("DeviceCapability")
            .Include("DeviceCapability.Capability")
            .FirstOrDefault();
      }
    }

    public Device FindByIdComplete(int id)
    {
      using (var context = new IntellihomeContext())
      {
        return context.Device
            .Where(d => d.Id.Equals(id))
            .Include("DeviceCapability")
            .Include("DeviceCapability.Capability")
            .FirstOrDefault();
      }
    }

    public List<Device> FindByUser(int userId)
    {
      using (var context = new IntellihomeContext())
      {
        List<Device> userDevices = context.User
            .Where(u => u.Id.Equals(userId))
            .Include("Device")
            .Include("Device.DeviceCapability")
            .Include("Device.DeviceCapability.Capability")
            .SelectMany(u => u.Device)
            .ToList();

        return userDevices.ToList();
      }
    }
  }
}