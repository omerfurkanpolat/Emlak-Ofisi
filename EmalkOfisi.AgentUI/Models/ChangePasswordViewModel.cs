using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmalkOfisi.AgentUI.Models
{
    public class ChangePasswordViewModel
    {
        [Display(Name ="Eski Şifre")]
        [Required(ErrorMessage = "Eski Şifre Alanını Girmek Zorunludur")]
        public string OldPassword { get; set; }
        [Display(Name = "Yeni  Şifre")]
        [Required(ErrorMessage = "Yeni  Şifre Alanını Girmek Zorunludur")]
        public string NewPassword { get; set; }
        [Compare("NewPassword",ErrorMessage ="Yeni Şifre ve Yeni Şifre Tekrar Alanları Eşleşmelidir")]
        [Display(Name = "Yeni Şifre Tekrar")]
        [Required(ErrorMessage = "Yeni Şifre Tekrar Alanını Girmek Zorunludur")]
        public string NewPasswordAgain { get; set; }
    }
}
