using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmalkOfisi.AgentUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email Alanı Girmek Zorunludur")]
        [Display(Name = "Email Adresi")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre Alanı Girmek Zorunludur")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
