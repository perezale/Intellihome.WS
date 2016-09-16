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
                    .Include("Capability")
                    .FirstOrDefault(d => d.Id.Equals(id));
            }
        }
    }
}