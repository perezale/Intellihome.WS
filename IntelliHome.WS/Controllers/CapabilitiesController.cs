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
  [RoutePrefix("api/Capabilities")]
  public class CapabilitiesController : ApiController
  {
    private CapabilityRepository capabilityRepository = new CapabilityRepository();
    public IEnumerable<Capability> Get()
    {
      return capabilityRepository.FindAll();
    }
  }
}
