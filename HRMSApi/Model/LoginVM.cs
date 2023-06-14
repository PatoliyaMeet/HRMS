using System.ComponentModel.DataAnnotations;

namespace HRMSApi.Model
{
    public class LoginVM
    {
        [Required(ErrorMessage = "EmailOrUserName can't be blank")]
        public string EmailOrUserName { get; set; }

        [Required(ErrorMessage = "Password can't be blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
