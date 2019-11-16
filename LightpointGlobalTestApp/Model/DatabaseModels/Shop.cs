using System;

namespace LightpointGlobalTestApp.Model.DatabaseModels
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string WorkingHours  { get; set; }

        public DateTime  CreateAt { get; set; }
        public DateTime LastUpdateAt { get; set; }
    }
}
