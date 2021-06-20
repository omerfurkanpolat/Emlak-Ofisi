using EmlakOfisi.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmlakOfisi.Entities.Concrete
{
    public class StateAd:IEntity
    {
        [Key]
        public int StateId { get; set; }
        public string AdName { get; set; }
        public string SatateAge { get; set; }
        public string StateArea { get; set; }
        public string RoomCount { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

    }
}
