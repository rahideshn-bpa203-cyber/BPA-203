using _35_ServiceLifeTimeAppSettingProductn.Models;

namespace _35_ServiceLifeTimeAppSettingProduct.Models
{
    public class Client : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
    }
}
