using HousingAPI.Models;
using HousingAPI.Models.PresentationModels.Management;
using System.Collections.Generic;
using System.Linq;

namespace HousingAPI.Controllers.Helpers
{
    public class ManagementsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        public IEnumerable<ManagementContactMapper> GetManagements()
        {
            var content = db.Managements.ToList();
            List<ManagementContactMapper> managements = new List<ManagementContactMapper>();
            foreach (var item in content)
            {
                ContactsHelper contact = new ContactsHelper();
                ManagementContactMapper management = new ManagementContactMapper
                {
                    ManagerId = item.managerId,
                    ContactId = item.contactId ?? 0,
                    DepartmentName = item.departmentName,

                    Contact = contact.GetContact(item.contactId ?? 0)
                };
                managements.Add(management);
            }
            return managements;
        }

        public ManagementContactMapper GetManagement(int id)
        {
            var content = db.Managements.Where(j => j.managerId == id).FirstOrDefault();
            if (content != null)
            {
                ContactsHelper contact = new ContactsHelper();
                ManagementContactMapper management = new ManagementContactMapper
                {
                    ManagerId = content.managerId,
                    ContactId = content.contactId ?? 0,
                    DepartmentName = content.departmentName,

                    Contact = contact.GetContact(content.contactId ?? 0)
                };
                return management;

            }

            return null;
        }


        /*
        // PUT: api/Managements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutManagement(int id, Management management)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != management.managerId)
            {
                return BadRequest();
            }

            db.Entry(management).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Managements
        [ResponseType(typeof(Management))]
        public IHttpActionResult PostManagement(Management management)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Managements.Add(management);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = management.managerId }, management);
        }

        // DELETE: api/Managements/5
        [ResponseType(typeof(Management))]
        public IHttpActionResult DeleteManagement(int id)
        {
            Management management = db.Managements.Find(id);
            if (management == null)
            {
                return NotFound();
            }

            db.Managements.Remove(management);
            db.SaveChanges();

            return Ok(management);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ManagementExists(int id)
        {
            return db.Managements.Count(e => e.managerId == id) > 0;
        }
        */
    }
}