using IntelliHome.WS.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelliHome.WS.Services
{
  public class CapabilityRepository
  {
    public List<Capability> FindAll()
    {
      using (var context = new IntellihomeContext())
      {
        return context.Capability.ToList();
      }
    }

  }
}