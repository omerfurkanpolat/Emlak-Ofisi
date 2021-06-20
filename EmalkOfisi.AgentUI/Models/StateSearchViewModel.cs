using EmlakOfisi.Entities.Concrete;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmalkOfisi.AgentUI.Models
{
    public class StateSearchViewModel
    {
        [Display(Name = "İlan Adı")]
        public string AddName { get; set; }
        [Display(Name = "Bina Yaşı")]
        public string StateAge { get; set; }
        [Display(Name = "Daire m2'si")]
        public string StateArea { get; set; }
        [Display(Name = "Oda Sayısı")]
        public string RoomCount { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Emlak Firması Adı")]
        public string AgentCompanyName { get; set; }
        public bool Search { get; set; } = false;
        public List<StateAd> StateAds { get; set; }
    }
}
