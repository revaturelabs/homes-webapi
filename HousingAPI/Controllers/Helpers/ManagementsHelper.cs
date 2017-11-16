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

            return new ManagementContactMapper();
        }



    }
}