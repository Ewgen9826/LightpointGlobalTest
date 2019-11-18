﻿using System.ComponentModel.DataAnnotations;

namespace LightpointGlobalTestApp.ViewModels.Item
{
    public class CreateItemViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ShopId { get; set; }
    }
}
