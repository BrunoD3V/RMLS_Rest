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
    public class PositionsController : ApiController
    {
        // GET: api/Positions
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Positions/5
        public Position Get(string id)
        {
            PositionsPersistence pp = new PositionsPersistence();
            Position p = pp.GetPositionByID(id);

            if (p != null)
                return p;
            else
                return null;
        }

        // POST: api/Positions
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Positions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Positions/5
        public void Delete(int id)
        {
        }
    }
}
