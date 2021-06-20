using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmalkOfisi.AgentUI.Models
{
    public class AgentSignUpViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Alanını Girmek Zorunludur")]
        [Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Alanını Girmek Zorunludur")]
        [Display(Name = "Email Adresi")]
        public string EmailAdress { get; set; }
        [Required(ErrorMessage = "Firma Adı Alanını Girmek Zorunludur")]
        [Display(Name = "Firma Adı")]
        public string AgentCompanyName { get; set; }
        [Required(ErrorMessage = "Firma Adı Alanını Girmek Zorunludur")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
