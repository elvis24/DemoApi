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
    public class CursoController : ApiController
    {
        // GET: api/Curso
        public IEnumerable<curso> Get()
        {
            using (escuelaEntities db = new escuelaEntities())
            {
                return db.curso.ToList();
            }
        }

        // GET: api/Curso/5
        [HttpGet]
        public curso Get(int id)
        {
                using (escuelaEntities db = new escuelaEntities())
                {
                    var curso = db.curso.FirstOrDefault(x => x.idCurso == id);
                    return curso;
                }
        }

        // POST: api/Curso
        public HttpResponseMessage Post([FromBody]curso cur)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (escuelaEntities db = new escuelaEntities())
                {
                    db.Entry(cur).State = EntityState.Added;
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

        // PUT: api/Curso/5
        public HttpResponseMessage Put([FromBody]curso cur)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (escuelaEntities db = new escuelaEntities())
                {
                    db.Entry(cur).State = EntityState.Modified;
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

        // DELETE: api/Curso/5
        public HttpResponseMessage Delete([FromBody]curso cur)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (escuelaEntities db = new escuelaEntities())
                {
                    db.Entry(cur).State = EntityState.Deleted;
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
