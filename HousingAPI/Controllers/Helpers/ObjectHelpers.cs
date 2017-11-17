using HousingAPI.Models.PresentationModels.HousingUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Controllers.Helpers
{
    public class SupplyViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public List<string> SupplyList { get; set; }
        public int SupplyRequestId { get; set; }
    }

    public class MaintenanceViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public int MaintenaceRequestId { get; set; }
    }

    public class ObjectHelpers
    {
        public List<SupplyViewModel> GetSupplyRequests()
        {
            HousingUnitsHelper helper = new HousingUnitsHelper();
            var content = helper.GetHousingUnitsSupplyRequest();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<SupplyViewModel> suppliesList = new List<SupplyViewModel>();
                List<string> nameList = new List<string>();
                foreach (var item in content)
                {
                    foreach (var tenant in item.Tenants)
                    {
                        foreach (var request in tenant.SupplyRequests)
                        {
                            foreach (var map in request.RequestSuppliesMaps)
                            {
                                nameList.Add(map.Supply.SupplyName);
                            }
                            SupplyViewModel supply = new SupplyViewModel
                            {
                                Name = tenant.Contact.FirstName + " " + tenant.Contact.LastName,
                                Address = item.Address.Name + " " + item.Address.StreetName + " " + item.HousingSignature,
                                Email = tenant.Contact.Email,
                                SupplyList = nameList,
                                SupplyRequestId = request.SupplyRequestId
                            };
                            suppliesList.Add(supply);
                        }
                    }
                }
                return suppliesList;
            }
        }

        public List<MaintenanceViewModel> GetMaintenanceRequests(int providerId)
        {
            HousingUnitsHelper helper = new HousingUnitsHelper();
            var content = helper.GetHousingUnitsMaintenanceRequest(providerId);
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<MaintenanceViewModel> maintenaceList = new List<MaintenanceViewModel>();
                foreach (var item in content)
                {
                    foreach (var tenant in item.Tenants)
                    {
                        foreach (var request in tenant.MaintenanceRequests)
                        {
                            MaintenanceViewModel maintenance = new MaintenanceViewModel
                            {
                                Name = tenant.Contact.FirstName + " " + tenant.Contact.LastName,
                                Address = item.Address.Name + " " + item.Address.StreetName + " " + item.HousingSignature,
                                Email = tenant.Contact.Email,
                                Message = request.Message,
                                MaintenaceRequestId = request.MaintenanceRequestId
                            };
                            maintenaceList.Add(maintenance);
                        }
                    }
                }
                return maintenaceList;
            }
        }
    }
     
    public List<HousingUnitProviderTenantSupplyMapper> GetHousingUnitsSupplyRequest()
    {
        var content = new List<HousingUnitProviderTenantSupplyMapper>();//db.HousingUnits.ToList();
        if (content.Count() == 0)
        {
            return null;
        }
        else
        {
            List<HousingUnitProviderTenantSupplyMapper> housingUnits = new List<HousingUnitProviderTenantSupplyMapper>();
            AddressesHelper address = new AddressesHelper();
            TenantsHelper tenants = new TenantsHelper();
            foreach (var item in content)
            {
                HousingUnitProviderTenantSupplyMapper housingUnit = new HousingUnitProviderTenantSupplyMapper
                {
                    HousingUnitId = item.housingUnitId,
                    ProviderId = item.providerId ?? 0,
                    AddressId = item.addressId ?? 0,
                    HousingSignature = item.housingSignature,
                    Capacity = item.capacity,

                    Address = address.GetAddress(item.addressId ?? 0),
                    Tenants = tenants.GetTenantsWithSupplies(item.housingUnitId)
                };
                housingUnits.Add(housingUnit);
            }
            return housingUnits;
        }
    }
}
}