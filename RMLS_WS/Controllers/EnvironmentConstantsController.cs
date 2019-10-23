using RMLS_WS.Models;
using RMLS_WS.Persistense;
using System.Collections.Generic;
using System.Web.Http;

namespace RMLS_WS.Controllers
{
    public class EnvironmentConstantsController : ApiController
    {
        // GET: api/EnvironmentConstants
        public List<EnvironmentConstant> Get()
        {
            EnvironmentConstantsPersistence ep = new EnvironmentConstantsPersistence();
            List<EnvironmentConstant> ec = ep.GetAllEnvironmentConstants();
            
            if (ec.Count > 0)
                return ec;
            else
                return null;
        }

        // POST: api/EnvironmentConstants
        public void Post([FromBody] EnvironmentConstant value)
        {
            EnvironmentConstantsPersistence evp = new EnvironmentConstantsPersistence();
            if (value != null)
                evp.InsertEnvironmentConstant(value);
        }
    }
}
