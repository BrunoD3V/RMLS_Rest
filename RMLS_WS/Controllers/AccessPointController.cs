using RMLS_WS.Models;
using RMLS_WS.Persistense;
using System.Collections.Generic;
using System.Web.Http;

namespace RMLS_WS.Controllers
{
    public class AccessPointController : ApiController
    {
        // GET: api/AccessPoint
        public List<AccessPoint> Get()
        {
            List<AccessPoint> accessPoints = new List<AccessPoint>();
            AccessPointPersistence ap = new AccessPointPersistence();
            
            accessPoints = ap.GetAllAccessPoints();
            
            return accessPoints;
        }

        // GET: api/AccessPoint/5
        public AccessPoint Get(string id)
        {
            AccessPoint accessPoints = new AccessPoint();
            AccessPointPersistence ap = new AccessPointPersistence();

            accessPoints = ap.GetAccessPointsByName(id);

            return accessPoints;
        }
    }
}
