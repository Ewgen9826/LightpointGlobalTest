using System.ComponentModel.DataAnnotations;

namespace LightpointGlobalTestApp.ViewModels.Shop
{
    public class CreateShopViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string WorkingHours { get; set; }
    }
}
