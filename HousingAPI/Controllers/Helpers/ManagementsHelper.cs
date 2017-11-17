using HousingAPI.Models;
using HousingAPI.Models.PresentationModels.Management;
using System.Collections.Generic;
using System.Linq;

namespace HousingAPI.Controllers.Helpers
{
    public class ManagementsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get All basic tables
        public IEnumerable<ManagementMapper> GetManagements()
        {
            var content = db.Managements.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<ManagementMapper> managements = new List<ManagementMapper>();
                ContactsHelper contact = new ContactsHelper();
                foreach (var item in content)
                {
                    ManagementMapper management = new ManagementMapper
                    {
                        ManagerId = item.managerId,
                        ContactId = item.contactId ?? 0,
                        DepartmentName = item.departmentName
                    };
                    managements.Add(management);
                }
                return managements;
            }
        }

        // Get One basic table
        public ManagementMapper GetManagement(int managerId)
        {
            var content = db.Managements.FirstOrDefault(j => j.managerId == managerId);
            if (content == null)
            {
                return null;
            }
            else
            {
                ContactsHelper contact = new ContactsHelper();
                ManagementMapper management = new ManagementMapper
                {
                    ManagerId = content.managerId,
                    ContactId = content.contactId ?? 0,
                    DepartmentName = content.departmentName
                };
                return management;
            }
        }

        // Get All management with contact
        public IEnumerable<ManagementContactMapper> GetManagementsWithContact()
        {
            var content = db.Managements.ToList();
            if(content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<ManagementContactMapper> managements = new List<ManagementContactMapper>();
                ContactsHelper contact = new ContactsHelper();
                foreach (var item in content)
                {
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
        }

        // Get One management with contact
        public ManagementContactMapper GetManagementWithContact(int managerId)
        {
            var content = db.Managements.FirstOrDefault(j => j.managerId == managerId);
            if (content == null)
            {
                return null;
            }
            else
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
        }
    }
}