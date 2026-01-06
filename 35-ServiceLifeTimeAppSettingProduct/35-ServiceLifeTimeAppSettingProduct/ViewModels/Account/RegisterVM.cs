using System.ComponentModel.DataAnnotations;

namespace _35_ServiceLifeTimeAppSettingProduct.ViewModels.Account
{
    public class RegisterVm
    {
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        [MinLength(3)]
        [MaxLength(20)]
        public string Surname { get; set; }
        [MinLength(4)]
        [MaxLength(50)]
        public string UserName { get; set; }
        [MinLength(3)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]

        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
