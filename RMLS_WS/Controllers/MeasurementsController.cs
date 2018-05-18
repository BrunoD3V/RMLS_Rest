using RMLS_WS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RMLS_WS.Controllers
{
    public class MeasurementsController : ApiController
    {
        // GET: api/Measurements
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Measurements/5
        public Measurement Get(string id)
        {
            MeasurementPersistence mp = new MeasurementPersistence();
            Measurement m = mp.GetMeasureByID(id);
            if (m != null)
                return m;
            else
                return null;
        }

        // POST: api/Measurements
        public void Post( [FromBody] Measurement value)
        {
            MeasurementPersistence mp = new MeasurementPersistence();
            if(value != null)
                mp.InsertMeasurement(value);
        }

        // PUT: api/Measurements/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Measurements/5
        public void Delete(int id)
        {
        }
    }
}
