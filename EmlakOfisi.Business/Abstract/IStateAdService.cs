using EmlakOfisi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmlakOfisi.Business.Abstract
{
    public interface IStateAdService
    {
        List<StateAd> GetStateAdByUserId(int id);
        StateAd GetStateAdById(int id);
        void CreateStateAd(StateAd stateAd);
        void Update(StateAd stateAd);
        void Delete(int id);
        List<StateAd> GetAllStateAds(string addName, string satateAge, string satateArea, string roomCount, string description, string agentCompanyName);
        StateAd GetStateByUserIdAndStateAdId(int userId, int stateId);
        StateAd GetStateAllPropsByStateAdId(int id);


      
    }
}
