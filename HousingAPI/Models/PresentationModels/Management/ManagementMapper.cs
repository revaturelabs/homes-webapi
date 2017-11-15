namespace HousingAPI.Models.HousingModels
{
    public abstract class ManagementMapper
    {
        public int managerId { get; set; }
        public int contactId { get; set; }
        public string departmentName { get; set; }

        // public virtual ContactMapper Contact { get; set; }
    }
}