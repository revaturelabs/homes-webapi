namespace HousingAPI.Models.HousingModels
{
    public abstract class AManagementMapper
    {
        public int ManagerId { get; set; }
        public int ContactId { get; set; }
        public string DepartmentName { get; set; }

        // public virtual ContactMapper Contact { get; set; }
    }
}