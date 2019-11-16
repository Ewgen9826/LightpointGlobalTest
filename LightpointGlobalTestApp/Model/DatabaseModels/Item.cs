using System;

namespace LightpointGlobalTestApp.Model.DatabaseModels
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreateAt { get; set; }
        public DateTime LastUpdateAt { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
