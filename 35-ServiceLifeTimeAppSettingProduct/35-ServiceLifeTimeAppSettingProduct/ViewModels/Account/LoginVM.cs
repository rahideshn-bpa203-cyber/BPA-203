using System.ComponentModel.DataAnnotations;

namespace _35_ServiceLifeTimeAppSettingProduct.ViewModels
{
    public class LoginVM
    {
        [MinLength(4)]
        [MaxLength(100)]
        public string UsernameOrEmail { get; set; }
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
       
    }
}
