using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace VideebackDemo.Models
{
    public class UserProfileController : ApiController
    {
        private UserProfileContext db = new UserProfileContext();

        // GET api/UserProfile
        public IEnumerable<UserProfile> GetUserPofiles()
        {
            return db.UserProfiles.AsEnumerable();
        }

        // GET api/UserProfile/5
        public UserProfile GetUserPofile(int id)
        {
            UserProfile userpofile = db.UserProfiles.Find(id);
            if (userpofile == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return userpofile;
        }

        // PUT api/UserProfile/5
        public HttpResponseMessage PutUserPofile(int id, UserProfile userpofile)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != userpofile.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(userpofile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/UserProfile
        public HttpResponseMessage PostUserPofile(UserProfile userpofile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(userpofile);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, userpofile);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = userpofile.id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/UserProfile/5
        public HttpResponseMessage DeleteUserPofile(int id)
        {
            UserProfile userpofile = db.UserProfiles.Find(id);
            if (userpofile == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.UserProfiles.Remove(userpofile);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, userpofile);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}