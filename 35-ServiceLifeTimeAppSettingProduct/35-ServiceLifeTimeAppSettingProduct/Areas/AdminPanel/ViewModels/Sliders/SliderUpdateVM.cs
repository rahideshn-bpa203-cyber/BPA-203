using System.ComponentModel.DataAnnotations.Schema;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.ViewModels.Sliders
{
    public class SliderUpdateVM
    {
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public IFormFile? Photo { get; set; }
    }
}
