using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakOfisi.AdminUI.Models
{
    public class SignUpViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı Adı Alanını Girmek Zorunludur")]
        public string UserName { get; set; }
        [Display(Name = "Email Adresi")]
        [Required(ErrorMessage = "Email Adresi Alanını Girmek Zorunludur")]
        public string EmailAdress { get; set; }
        [Required(ErrorMessage = "Şifre Alanını Girmek Zorunludur")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
