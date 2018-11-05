using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreReport.Models.AccountViewModels
{
    public class RegisterViewModel
    {
 
        [Required(ErrorMessage = "El correo es requerido.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [StringLength(100, ErrorMessage = "La contraseña {0} debe ser tener como mínimo {2} caracteres y como máximo {1}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm_Views_Account_Registerar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la confirmación de contraseña no son iguales.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "La empresa es requerida.")]
        [StringLength(100, ErrorMessage = "La empresa {0} debe ser tener como mínimo {2} caracteres y como máximo {1}.", MinimumLength = 4
            )]
        [DataType(DataType.Text)]
        [Display(Name = "Enterprise")]
        public string Enterprise { get; set; }
    }
}
