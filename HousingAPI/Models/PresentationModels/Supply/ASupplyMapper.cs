﻿namespace HousingAPI.Models.HousingModels
{
    public abstract class ASupplyMapper
    {
        public int SupplyId { get; set; }
        public string SupplyName { get; set; }

        //public List<RequestSuppliesMapMapper> RequestSuppliesMaps { get; set; }
    }
}