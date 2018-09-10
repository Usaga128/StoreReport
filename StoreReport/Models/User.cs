using System.ComponentModel.DataAnnotations;

namespace StoreReport.Models
{
    public class User
    {
 
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm_Views_Account_Registerar contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y la confirmación de contraseña no son iguales.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Text)]
            [Display(Name = "Enterprise")]
            public string Enterprise { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}
