using IntelliHome.WS.Models.Db;
using IntelliHome.WS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntelliHome.WS.Controllers
{
  [RoutePrefix("api/Devices")]
  public class DevicesController : ApiController
  {
    private DeviceRepository deviceRepository = new DeviceRepository();

    public IEnumerable<Device> Get()
    {
      return deviceRepository.FindAll();
    }

    [Route("{id:int}")]
    public Device Get(int id)
    {
      return deviceRepository.FindById(id);
    }

    [Route("{id:int}/Capabilities")]
    public IEnumerable<Capability> GetCapabilitiesByDevice(int id)
    {
      var device = deviceRepository.FindByIdComplete(id);
      return device.DeviceCapability.Select(dc => dc.Capability);      
    }
  }
}
