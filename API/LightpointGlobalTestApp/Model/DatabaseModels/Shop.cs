using System;
using System.Collections.Generic;

namespace LightpointGlobalTestApp.Model.DatabaseModels
{
    public class Shop
    {
        public Shop()
        {
            Items = new List<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string WorkingHours  { get; set; }

        public DateTime  CreateAt { get; set; }
        public DateTime LastUpdateAt { get; set; }

        public List<Item> Items { get; set; }
    }
}
