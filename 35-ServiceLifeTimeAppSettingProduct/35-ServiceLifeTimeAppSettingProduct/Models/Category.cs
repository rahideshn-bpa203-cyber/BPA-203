using _35_ServiceLifeTimeAppSettingProductn.Models;
using System.ComponentModel.DataAnnotations;

namespace _35_ServiceLifeTimeAppSettingProduct.Models
{
    public class Category:BaseEntity
    {
        //[Required(ErrorMessage ="bos olmaz")]
        [MaxLength(20,ErrorMessage ="max 20 herf olmalidir!!")]
        public string? Name { get; set; }
        public List<Product> Products { get; set; }
 
    }
}
