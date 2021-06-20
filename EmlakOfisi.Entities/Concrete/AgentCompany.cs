using EmlakOfisi.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmlakOfisi.Entities.Concrete
{
    public class AgentCompany:IEntity
    {
        [Key]
        public int AgentCompanyId { get; set; }
        public string AgentCompanyName { get; set; }
        public List<User> Users { get; set; }
    }
}
