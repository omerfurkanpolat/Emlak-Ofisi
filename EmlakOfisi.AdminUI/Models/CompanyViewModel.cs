using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakOfisi.AdminUI.Models
{
    public class CompanyViewModel
    {
        [Required]
        public string CompanyName { get; set; }
    }
}
