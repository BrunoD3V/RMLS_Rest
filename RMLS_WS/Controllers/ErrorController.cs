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
    public class ErrorController : ApiController
    {
        // GET: api/Error
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Error/5
        public Error Get(string posID)
        {
            ErrorPersistence ep = new ErrorPersistence();

            Error result = new Error();

            if (posID != String.Empty)
            {
               result = ep.GetErrorByPosID(posID);
            }

            return result;
        }

        // POST: api/Error
        public void Post([FromBody] Error value)
        {
            ErrorPersistence evp = new ErrorPersistence();
            if (value != null)
                evp.InsertError(value);
        }

        // PUT: api/Error/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Error/5
        public void Delete(int id)
        {
        }
    }
}
