using EmlakOfisi.Core.DataAcces;
using EmlakOfisi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmlakOfisi.Dal.Absctract
{
    public interface IStateAdDal : IEntityRepository<StateAd>
    {
        List<StateAd> GetStateAdsAllProps(string addName, string satateAge, string satateArea, string roomCount, string description, string agentCompanyName);
        StateAd GetStateAllPropsByStatesAdId(int id);
    }
}
