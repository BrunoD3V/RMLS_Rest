using RMLS_WS.Models;
using RMLS_WS.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RMLS_WS.Controllers
{
    public class EnvironmentConstantsController : ApiController
    {
        // GET: api/EnvironmentConstants
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EnvironmentConstants/5
        public List<EnvironmentConstant> Get(string equipType)
        {
            EnvironmentConstantsPersistence ep = new EnvironmentConstantsPersistence();
            List<EnvironmentConstant> ec = ep.GetEnvironmentConstantByEquipType(equipType);
            
            if (ec.Count > 0)
                return ec;
            else
                return null;
        }

        // POST: api/EnvironmentConstants
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EnvironmentConstants/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EnvironmentConstants/5
        public void Delete(int id)
        {
        }
    }
}
