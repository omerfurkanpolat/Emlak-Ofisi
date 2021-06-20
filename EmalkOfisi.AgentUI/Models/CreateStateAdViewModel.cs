using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmalkOfisi.AgentUI.Models
{
    public class CreateStateAdViewModel
    {
        [Display(Name ="İlan Adı")]
        [Required(ErrorMessage ="İlan Adı Boş Bırakılamaz")]
        public string AdName { get; set; }
       
        [Display(Name = "Binanın Yaşı")]       
        public string SatateAge { get; set; }
        [Display(Name = "Dairenin m2 si")]
        [Required(ErrorMessage = "Dairenin m2'si alanı boş bırakılamaz")]
        public string StateArea { get; set; }
        [Display(Name = "Oda Sayısı")]
        [Required(ErrorMessage = "Oda Sayısı alanı boş bırakılamaz")]
        public string RoomCount { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}
