﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakOfisi.AdminUI.Models
{
    public class AgentSignupViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı Alanını Girmek Zorunludur")]
        public string UserName { get; set; }
        [Display(Name = "Email Adresi")]
        [Required(ErrorMessage = "Email Alanını Girmek Zorunludur")]
        public string EmailAdress { get; set; }
        [Display(Name = "Firma Adı")]
        [Required(ErrorMessage = "Firma Adı Alanını Girmek Zorunludur")]
        public string AgentCompanyName { get; set; }
    }
}
