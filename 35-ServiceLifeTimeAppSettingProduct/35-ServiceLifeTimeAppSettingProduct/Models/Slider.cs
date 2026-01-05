using _35_ServiceLifeTimeAppSettingProductn.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace _35_ServiceLifeTimeAppSettingProductn.Models
{
    public class Slider : BaseEntity
    {
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
      



    }
}
