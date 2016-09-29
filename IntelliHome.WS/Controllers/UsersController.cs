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
  [RoutePrefix("api/Users")]
  public class UsersController : ApiController
  {

    private UserRepository userRepository = new UserRepository();
    private DeviceRepository deviceRepository = new DeviceRepository();

    public IEnumerable<User> Get()
    {
      return userRepository.FindAll();
    }

    [Route("{id:int}/Devices")]
    public IEnumerable<Device> GetDevicesByUser(int id)
    {
      return deviceRepository.FindByUser(id);
    }
  }
}
