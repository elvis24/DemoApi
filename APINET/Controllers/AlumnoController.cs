using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Datos;

namespace APINET.Controllers
{
    public class AlumnoController : ApiController
    {
        // GET: api/Alumno
        public IEnumerable<alumno> Get()
        {
            using (escuelaEntities db = new escuelaEntities())
            {
                return db.alumno.ToList();
            }
        }

        // GET: api/Alumno/5
        public alumno Get(int id)
        {
            using (escuelaEntities db = new escuelaEntities())
            {
                var alumno = db.alumno.FirstOrDefault(x => x.id == id);
                return alumno;
            }
        }

        // POST: api/Alumno
        public HttpResponseMessage Post([FromBody]alumno alum)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (escuelaEntities db = new escuelaEntities())
                {
                    db.Entry(alum).State = EntityState.Added;
                    resp = db.SaveChanges();
                    msg = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception ex)
            {
                msg.RequestMessage.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return msg;
        }

        // PUT: api/Alumno/5
        public HttpResponseMessage Put([FromBody]alumno alum)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (escuelaEntities db = new escuelaEntities())
                {
                    db.Entry(alum).State = EntityState.Modified;
                    resp = db.SaveChanges();
                    msg = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception ex)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return msg;
        }

        // DELETE: api/Alumno/5
        public HttpResponseMessage Delete([FromBody]alumno alum)
        {
            int resp = 0;
            HttpResponseMessage msg = null;

            try
            {
                using (escuelaEntities db = new escuelaEntities())
                {
                    db.Entry(alum).State = EntityState.Deleted;
                    resp = db.SaveChanges();
                    msg = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception ex)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return msg;
        }
    }
}
