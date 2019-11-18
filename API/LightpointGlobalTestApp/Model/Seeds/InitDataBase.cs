using LightpointGlobalTestApp.Model.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightpointGlobalTestApp.Model.Seeds
{
    public class InitDataBase
    {
        public static void Seed(ApplicationDatabaseContext context)
        {
            if (context.Shops.Count() != 0) return;
            var shop1 = new Shop 
            { 
                Name = "Aenean euismod elementum", 
                Address = "ул. Спасопесковская Площадь, дом 89", 
                WorkingHours = "09:00-21:00" 
            };

            var shop2 = new Shop
            {
                Name = "Sagittis nisl",
                Address = "ул. Перервинский Бульвар, дом 16",
                WorkingHours = "08:00-20:00"
            };

            var shop3 = new Shop
            {
                Name = "Augue neque",
                Address = "ул. Савеловского Вокзала Площадь, дом 49",
                WorkingHours = "07:00-22:00"
            };

            var item1 = new Item
            {
                Name = "fermentum dui",
                Description = "dis parturient montes nascetur ridiculus",
                Shop = shop1
            };

            var item2 = new Item
            {
                Name = "amet nisl",
                Description = "amet justo donec enim diam",
                Shop = shop2
            };

            var item3 = new Item
            {
                Name = "non odio",
                Description = "bibendum arcu vitae elementum curabitur",
                Shop = shop3
            };

            var item4 = new Item
            {
                Name = "posuere urna",
                Description = "in fermentum et sollicitudin ac",
                Shop = shop1
            };

            var item5 = new Item
            {
                Name = "semper quis",
                Description = "vitae justo eget magna fermentum",
                Shop = shop1
            };

            var item6 = new Item
            {
                Name = "nunc consequat",
                Description = "nisi quis eleifend quam adipiscing",
                Shop = shop2
            };

            var item7 = new Item
            {
                Name = "morbi blandit",
                Description = "amet nisl suscipit adipiscing bibendum",
                Shop = shop3
            };

            var item8 = new Item
            {
                Name = "est ultricies",
                Description = "aliquam id diam maecenas ultricies",
                Shop = shop1
            };

            context.Shops.AddRange(new Shop[] { shop1, shop2, shop3 });
            context.Items.AddRange(new Item[] { item1, item2, item3, item4, item5, item6, item7, item8 });
            context.SaveChanges();
        }
    }
}
