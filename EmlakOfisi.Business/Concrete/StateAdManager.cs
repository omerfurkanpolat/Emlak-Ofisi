using EmlakOfisi.Business.Abstract;
using EmlakOfisi.Dal.Absctract;
using EmlakOfisi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmlakOfisi.Business.Concrete
{
    public class StateAdManager : IStateAdService
    {
        private IStateAdDal _stateAdDal;

        public StateAdManager(IStateAdDal stateAdDal)
        {
            _stateAdDal = stateAdDal;
        }

        public void CreateStateAd(StateAd stateAd)
        {
            _stateAdDal.Add(stateAd);
        }

        public void Delete(int id)
        {
            _stateAdDal.Delete(new StateAd() { StateId = id });
        }

        public StateAd GetStateAdById(int id)
        {
            return _stateAdDal.Get(x => x.StateId == id);
        }

        public List<StateAd> GetStateAdByUserId(int id)
        {
            return _stateAdDal.GetList(x => x.UserId == id);
        }

        public List<StateAd> GetAllStateAds(string addName, string satateAge, string satateArea, string roomCount, string description, string agentCompanyName)
        {
            return _stateAdDal.GetStateAdsAllProps(addName, satateAge, satateArea, roomCount, description, agentCompanyName);
        }

        public void Update(StateAd stateAd)
        {
            _stateAdDal.Update(stateAd);
        }

        public StateAd GetStateByUserIdAndStateAdId(int userId, int stateId)
        {
            return _stateAdDal.Get(x => x.UserId == userId && x.StateId == stateId);
        }

        public StateAd GetStateAllPropsByStateAdId(int id)
        {
            return _stateAdDal.GetStateAllPropsByStatesAdId(id);
        }
    }
}
