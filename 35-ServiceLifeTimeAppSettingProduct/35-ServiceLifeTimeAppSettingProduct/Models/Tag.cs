using _35_ServiceLifeTimeAppSettingProductn.Models;

namespace _35_ServiceLifeTimeAppSettingProduct.Models
{
    public class Tag:BaseEntity
    {

        public string Name { get; set; }
        public List<ProductTag> ProductTags { get; set; }
    }
}
