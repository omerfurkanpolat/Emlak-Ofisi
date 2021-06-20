using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmlakOfisi.Entities.Concrete
{
    public class User:IdentityUser<int>
    {
        public string AgentCompanyName { get; set; }
        public int AgentCompnayId { get; set; }
        public AgentCompany AgentCompany { get; set; }
        public List<StateAd> StateAds { get; set; }
    }
}
