using RMLS_WS.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RMLS_WS.Controllers
{
    public class MeasurementsController : ApiController
    {
        // GET: api/Measurements
        public List<Measurement> Get(int? id = null)
        {
            List<Measurement> measurementsList = new List<Measurement>();

            MeasurementPersistence mp = new MeasurementPersistence();
            if (id != null)
            {
                string posID = string.Format("pos{0}", id);
                measurementsList = mp.GetAllMeasuresByPosID(posID);
            }
            else
            {
                measurementsList = mp.GetAllMeasures();
            }

            return measurementsList;
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
        public void Post([FromBody] Measurement value)
        {
            MeasurementPersistence mp = new MeasurementPersistence();
            if (value != null)
                mp.InsertMeasurement(value);
        }

        // PUT: api/Measurements/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Measurements/5
        public HttpResponseMessage Delete(string id)
        {
            MeasurementPersistence mp = new MeasurementPersistence();
            bool recordExists = false;
            recordExists = mp.DeleteMeasurement(id);

            HttpResponseMessage response;

            if (recordExists)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return response;
        }
    }
}