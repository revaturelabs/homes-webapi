using HousingAPI.Models;
using HousingAPI.Models.PresentationModels.Tenant;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HousingAPI.Controllers.Helpers
{
    public class TenantsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get all basic tables
        public IEnumerable<TenantMapper> GetTenants()
        {
            var content = db.Tenants.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<TenantMapper> tenants = new List<TenantMapper>();
                foreach (var item in content)
                {
                    TenantMapper tenant = new TenantMapper
                    {
                        TenantId = item.tenantId,
                        ContactId = item.contactId ?? 0,
                        BatchId = item.batchId ?? 0,
                        HousingUnitId = item.housingUnitId ?? 0,
                        GenderId = item.genderId ?? 0,
                        MoveInDate = item.moveInDate,
                        HasMoved = item.hasMoved ?? default(bool),
                        HasKey = item.hasKey ?? default(bool)
                    };
                    tenants.Add(tenant);
                }
                return tenants;
            }
        }

        // Get one basic table
        public TenantMapper GetTenant(int id)
        {
            var content = db.Tenants.FirstOrDefault(j => j.tenantId == id);

            if (content == null)
            {
                return null;
            }
            else
            {
                TenantMapper tenant = new TenantMapper
                {
                    TenantId = content.tenantId,
                    ContactId = content.contactId ?? 0,
                    BatchId = content.batchId ?? 0,
                    HousingUnitId = content.housingUnitId ?? 0,
                    GenderId = content.genderId ?? 0,
                    MoveInDate = content.moveInDate,
                    HasMoved = content.hasMoved ?? default(bool),
                    HasKey = content.hasKey ?? default(bool)
                };
                return tenant;
            }
        }

        // Get all tenants for address
        public IEnumerable<TenantBatchMapper> GetTenantsWithBatch()
        {
            var content = db.Tenants.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<TenantBatchMapper> tenants = new List<TenantBatchMapper>();
                BatchesHelpers batch = new BatchesHelpers();
                ContactsHelper contact = new ContactsHelper();
                GendersHelper gender = new GendersHelper();
                TenantCarRelationshipsHelper tenantCarRelationships = new TenantCarRelationshipsHelper();
                foreach (var item in content)
                {
                    TenantBatchMapper tenant = new TenantBatchMapper
                    {
                        TenantId = item.tenantId,
                        ContactId = item.contactId ?? 0,
                        BatchId = item.batchId ?? 0,
                        HousingUnitId = item.housingUnitId ?? 0,
                        GenderId = item.genderId ?? 0,
                        MoveInDate = item.moveInDate,
                        HasMoved = item.hasMoved ?? default(bool),
                        HasKey = item.hasKey ?? default(bool),

                        Batch = batch.GetBatch(item.batchId ?? 0),
                        Contact = contact.GetContact(item.contactId ?? 0),
                        Gender = gender.GetGender(item.genderId ?? 0),
                        TenantCarRelationships = tenantCarRelationships.GetTenantCarRelationship(item.tenantId)
                    };
                    tenants.Add(tenant);
                }
                return tenants;
            }
        }

        // Get tenants of a batch for address
        public IEnumerable<TenantBatchMapper> GetTenantsWithBatchByBatch(int batchId)
        {
            var content = db.Tenants.Where(j => j.batchId == batchId).ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<TenantBatchMapper> tenants = new List<TenantBatchMapper>();
                BatchesHelpers batch = new BatchesHelpers();
                ContactsHelper contact = new ContactsHelper();
                GendersHelper gender = new GendersHelper();
                TenantCarRelationshipsHelper tenantCarRelationships = new TenantCarRelationshipsHelper();
                foreach (var item in content)
                {
                    TenantBatchMapper tenant = new TenantBatchMapper
                    {
                        TenantId = item.tenantId,
                        ContactId = item.contactId ?? 0,
                        BatchId = item.batchId ?? 0,
                        HousingUnitId = item.housingUnitId ?? 0,
                        GenderId = item.genderId ?? 0,
                        MoveInDate = item.moveInDate,
                        HasMoved = item.hasMoved ?? default(bool),
                        HasKey = item.hasKey ?? default(bool),

                        Batch = batch.GetBatch(item.batchId ?? 0),
                        Contact = contact.GetContact(item.contactId ?? 0),
                        Gender = gender.GetGender(item.genderId ?? 0),
                        TenantCarRelationships = tenantCarRelationships.GetTenantCarRelationship(item.tenantId)
                    };
                    tenants.Add(tenant);
                }
                return tenants;
            }
        }

        // Get a list of tenants by housing unit, used in HousingUnits
        public IEnumerable<TenantBatchMapper> GetTenantsWithInfoByHousing(int housingId)
        {
            var content = db.Tenants.Where(j => j.housingUnitId == housingId).ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<TenantBatchMapper> tenants = new List<TenantBatchMapper>();
                BatchesHelpers batch = new BatchesHelpers();
                ContactsHelper contact = new ContactsHelper();
                GendersHelper gender = new GendersHelper();
                TenantCarRelationshipsHelper tenantCarRelationships = new TenantCarRelationshipsHelper();
                foreach (var item in content)
                {
                    TenantBatchMapper tenant = new TenantBatchMapper
                    {
                        TenantId = item.tenantId,
                        ContactId = item.contactId ?? 0,
                        BatchId = item.batchId ?? 0,
                        HousingUnitId = item.housingUnitId ?? 0,
                        GenderId = item.genderId ?? 0,
                        MoveInDate = item.moveInDate,
                        HasMoved = item.hasMoved ?? default(bool),
                        HasKey = item.hasKey ?? default(bool),

                        Batch = batch.GetBatch(item.batchId ?? 0),
                        Contact = contact.GetContact(item.contactId ?? 0),
                        Gender = gender.GetGender(item.genderId ?? 0),
                        TenantCarRelationships = tenantCarRelationships.GetTenantCarRelationship(item.tenantId)
                    };
                    tenants.Add(tenant);
                }
                return tenants;
            }
        }

        // Get one tenant for address
        public TenantBatchMapper GetTenantWithBatch(int tenantId)
        {
            var content = db.Tenants.FirstOrDefault(j => j.tenantId == tenantId);

            if (content == null)
            {
                return null;
            }
            else
            {
                BatchesHelpers batch = new BatchesHelpers();
                ContactsHelper contact = new ContactsHelper();
                GendersHelper gender = new GendersHelper();
                TenantCarRelationshipsHelper tenantCarRelationships = new TenantCarRelationshipsHelper();

                TenantBatchMapper tenant = new TenantBatchMapper
                {
                    TenantId = content.tenantId,
                    ContactId = content.contactId ?? 0,
                    BatchId = content.batchId ?? 0,
                    HousingUnitId = content.housingUnitId ?? 0,
                    GenderId = content.genderId ?? 0,
                    MoveInDate = content.moveInDate,
                    HasMoved = content.hasMoved ?? default(bool),
                    HasKey = content.hasKey ?? default(bool),

                    Batch = batch.GetBatch(content.batchId ?? 0),
                    Contact = contact.GetContact(content.contactId ?? 0),
                    Gender = gender.GetGender(content.genderId ?? 0),
                    TenantCarRelationships = tenantCarRelationships.GetTenantCarRelationship(content.tenantId)
                };
                return tenant;
            }
        }

        // Get tenants for batch
        public IEnumerable<TenantAddressMapper> GetTenantsWithAddress()
        {
            var content = db.Tenants.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<TenantAddressMapper> tenants = new List<TenantAddressMapper>();
                HousingUnitsHelper housingUnits = new HousingUnitsHelper();
                ContactsHelper contact = new ContactsHelper();
                GendersHelper gender = new GendersHelper();
                TenantCarRelationshipsHelper car = new TenantCarRelationshipsHelper();
                foreach (var item in content)
                {
                    TenantAddressMapper tenant = new TenantAddressMapper
                    {
                        TenantId = item.tenantId,
                        ContactId = item.contactId ?? 0,
                        BatchId = item.batchId ?? 0,
                        HousingUnitId = item.housingUnitId ?? 0,
                        GenderId = item.genderId ?? 0,
                        MoveInDate = item.moveInDate,
                        HasMoved = item.hasMoved ?? default(bool),
                        HasKey = item.hasKey ?? default(bool),

                        HousingUnit = housingUnits.GetHousingUnitWithAddress(item.housingUnitId ?? 0),
                        Contact = contact.GetContact(item.contactId ?? 0),
                        Gender = gender.GetGender(item.genderId ?? 0),
                        TenantCarRelationships = car.GetTenantCarRelationship(item.tenantId)
                    };
                    tenants.Add(tenant);
                }
                return tenants;
            }
        }

        // Default
        public IEnumerable<TenantInfoMapper> GetTenantsInfo()
        {
            var content = db.Tenants.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<TenantInfoMapper> tenants = new List<TenantInfoMapper>();
                HousingUnitsHelper housingUnits = new HousingUnitsHelper();
                BatchesHelpers batch = new BatchesHelpers();
                ContactsHelper contact = new ContactsHelper();
                GendersHelper gender = new GendersHelper();
                TenantCarRelationshipsHelper tenantCarRelationships = new TenantCarRelationshipsHelper();
                foreach (var item in content)
                {
                    TenantInfoMapper tenant = new TenantInfoMapper
                    {
                        TenantId = item.tenantId,
                        ContactId = item.contactId ?? 0,
                        BatchId = item.batchId ?? 0,
                        HousingUnitId = item.housingUnitId ?? 0,
                        GenderId = item.genderId ?? 0,
                        MoveInDate = item.moveInDate,
                        HasMoved = item.hasMoved ?? default(bool),
                        HasKey = item.hasKey ?? default(bool),

                        HousingUnit = housingUnits.GetHousingUnitWithAddress(item.housingUnitId ?? 0),
                        Batch = batch.GetBatch(item.batchId ?? 0),
                        Contact = contact.GetContact(item.contactId ?? 0),
                        Gender = gender.GetGender(item.genderId ?? 0),
                        TenantCarRelationships = tenantCarRelationships.GetTenantCarRelationship(item.tenantId)
                    };
                    tenants.Add(tenant);
                }
                return tenants;
            }
        }

        // Default
        public TenantInfoMapper GetTenantInfo(int tenantId)
        {
            var content = db.Tenants.FirstOrDefault(j => j.tenantId == tenantId);
            if (content == null)
            {
                return null;
            }
            else
            {
                HousingUnitsHelper housingUnits = new HousingUnitsHelper();
                BatchesHelpers batch = new BatchesHelpers();
                ContactsHelper contact = new ContactsHelper();
                GendersHelper gender = new GendersHelper();
                TenantCarRelationshipsHelper car = new TenantCarRelationshipsHelper();

                TenantInfoMapper tenant = new TenantInfoMapper
                {
                    TenantId = content.tenantId,
                    ContactId = content.contactId ?? 0,
                    BatchId = content.batchId ?? 0,
                    HousingUnitId = content.housingUnitId ?? 0,
                    GenderId = content.genderId ?? 0,
                    MoveInDate = content.moveInDate,
                    HasMoved = content.hasMoved ?? default(bool),
                    HasKey = content.hasKey ?? default(bool),

                    HousingUnit = housingUnits.GetHousingUnitWithAddress(content.housingUnitId ?? 0),
                    Batch = batch.GetBatch(content.batchId ?? 0),
                    Contact = contact.GetContact(content.contactId ?? 0),
                    Gender = gender.GetGender(content.genderId ?? 0),
                    TenantCarRelationships = car.GetTenantCarRelationship(content.tenantId)
                };
                return tenant;
            }
        }

        // All Tenants with supply request
        public IEnumerable<TenantSupplyMapper> GetTenantsWithSupply()
        {
            var content = db.Tenants.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<TenantSupplyMapper> tenants = new List<TenantSupplyMapper>();
                foreach (var item in content)
                {
                    SupplyRequestsHelper supply = new SupplyRequestsHelper();

                    TenantSupplyMapper tenant = new TenantSupplyMapper
                    {
                        TenantId = item.tenantId,
                        ContactId = item.contactId ?? 0,
                        BatchId = item.batchId ?? 0,
                        HousingUnitId = item.housingUnitId ?? 0,
                        GenderId = item.genderId ?? 0,
                        MoveInDate = item.moveInDate,
                        HasMoved = item.hasMoved ?? default(bool),
                        HasKey = item.hasKey ?? default(bool),

                        //SupplyRequests = supply.GetSupplyRequests()
                    };
                    tenants.Add(tenant);
                }
                return tenants;
            }
        }

        // Get tenants of a housing unit with its supply request
        public List<TenantSupplyMapper> GetTenantsWithSupplies(int housingUnitId)
        {
            var content = db.Tenants.Where(j => j.housingUnitId == housingUnitId).ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<TenantSupplyMapper> tenants = new List<TenantSupplyMapper>();
                SupplyRequestsHelper requests = new SupplyRequestsHelper();
                foreach (var item in content)
                {
                    TenantSupplyMapper tenant = new TenantSupplyMapper
                    {
                        TenantId = item.tenantId,
                        ContactId = item.contactId ?? 0,
                        BatchId = item.batchId ?? 0,
                        HousingUnitId = item.housingUnitId ?? 0,
                        GenderId = item.genderId ?? 0,
                        MoveInDate = item.moveInDate,
                        HasMoved = item.hasMoved ?? default(bool),
                        HasKey = item.hasKey ?? default(bool),

                        SupplyRequests = requests.GetSupplyRequestWithSupplies(item.tenantId)
                    };
                    tenants.Add(tenant);
                }
                return tenants;
            }
        }

        // One Tenant with supply request
        public TenantSupplyMapper GetTenantWithSupply(int tenantId)
        {
            var content = db.Tenants.FirstOrDefault(j => j.tenantId == tenantId);
            if (content == null)
            {
                return null;
            }
            else
            {
                SupplyRequestsHelper supply = new SupplyRequestsHelper();

                TenantSupplyMapper tenant = new TenantSupplyMapper
                {
                    TenantId = content.tenantId,
                    ContactId = content.contactId ?? 0,
                    BatchId = content.batchId ?? 0,
                    HousingUnitId = content.housingUnitId ?? 0,
                    GenderId = content.genderId ?? 0,
                    MoveInDate = content.moveInDate,
                    HasMoved = content.hasMoved ?? default(bool),
                    HasKey = content.hasKey ?? default(bool),

                    //SupplyRequests = supply.GetSupplyRequests()
                };
                return tenant;
            }
        }

        // All Tenants with maintenance request
        public IEnumerable<TenantMaintenanceMapper> GetTenantsWithMaintenance()
        {
            var content = db.Tenants.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<TenantMaintenanceMapper> tenants = new List<TenantMaintenanceMapper>();
                foreach (var item in content)
                {
                    MaintenanceRequestsHelper maintenance = new MaintenanceRequestsHelper();

                    TenantMaintenanceMapper tenant = new TenantMaintenanceMapper
                    {
                        TenantId = item.tenantId,
                        ContactId = item.contactId ?? 0,
                        BatchId = item.batchId ?? 0,
                        HousingUnitId = item.housingUnitId ?? 0,
                        GenderId = item.genderId ?? 0,
                        MoveInDate = item.moveInDate,
                        HasMoved = item.hasMoved ?? default(bool),
                        HasKey = item.hasKey ?? default(bool),

                        MaintenanceRequests = maintenance.GetMaintenanceRequestsByTenant(item.tenantId)
                    };
                    tenants.Add(tenant);
                }
                return tenants;
            }
        }

        // Get tenants of a housing unit with its maintenance request
        public List<TenantMaintenanceMapper> GetTenantsWithMaintenance(int housingUnitId)
        {
            var content = db.Tenants.Where(j => j.housingUnitId == housingUnitId).ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<TenantMaintenanceMapper> tenants = new List<TenantMaintenanceMapper>();
                MaintenanceRequestsHelper maintenance = new MaintenanceRequestsHelper();
                foreach (var item in content)
                {
                    TenantMaintenanceMapper tenant = new TenantMaintenanceMapper
                    {
                        TenantId = item.tenantId,
                        ContactId = item.contactId ?? 0,
                        BatchId = item.batchId ?? 0,
                        HousingUnitId = item.housingUnitId ?? 0,
                        GenderId = item.genderId ?? 0,
                        MoveInDate = item.moveInDate,
                        HasMoved = item.hasMoved ?? default(bool),
                        HasKey = item.hasKey ?? default(bool),

                        MaintenanceRequests = maintenance.GetMaintenanceRequestsByTenant(item.tenantId)
                    };
                    tenants.Add(tenant);
                }
                return tenants;
            }
        }

        // One Tenant with maintenance request
        public IEnumerable<TenantAddressMapper> GetTenantsInfoByBatch(int batchId)
        {
            var content = db.Tenants.Where(j => j.batchId == batchId).ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<TenantAddressMapper> tenants = new List<TenantAddressMapper>();
                
                HousingUnitsHelper housingUnit = new HousingUnitsHelper();
                ContactsHelper contact = new ContactsHelper();
                GendersHelper gender = new GendersHelper();
                TenantCarRelationshipsHelper car = new TenantCarRelationshipsHelper();

                foreach (var item in content)
                {
                    TenantAddressMapper tenant = new TenantAddressMapper
                    {
                        TenantId = item.tenantId,
                        ContactId = item.contactId ?? 0,
                        BatchId = item.batchId ?? 0,
                        HousingUnitId = item.housingUnitId ?? 0,
                        GenderId = item.genderId ?? 0,
                        MoveInDate = item.moveInDate,
                        HasMoved = item.hasMoved ?? default(bool),
                        HasKey = item.hasKey ?? default(bool),
                        
                        HousingUnit = housingUnit.GetHousingUnitWithAddress(item.housingUnitId ?? 0),
                        Contact = contact.GetContact(item.contactId ?? 0),
                        Gender = gender.GetGender(item.genderId ?? 0),
                        TenantCarRelationships = car.GetTenantCarRelationship(item.tenantId)
                    };
                    tenants.Add(tenant);
                }
                return tenants;
            }
        }
    }
}