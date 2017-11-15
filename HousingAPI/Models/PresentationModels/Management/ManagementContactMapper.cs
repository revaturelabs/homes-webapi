using HousingAPI.Models.HousingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.PresentationModels.Management
{
    public class ManagementContactMapper
    {
        public int ManagerId { get; set; }
        public int ContactId { get; set; }
        public string DepartmentName { get; set; }

        public ContactMapper Contact { get; set; }
    }
}