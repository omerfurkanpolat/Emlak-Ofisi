using EmlakOfisi.Core.DataAcces.EntityFramework;
using EmlakOfisi.Dal.Absctract;
using EmlakOfisi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmlakOfisi.Dal.Concrete.EntityFramework
{
    public class EfStateAdDal : EfEntityRepositoryBase<StateAd, EmlakOfisiContext>, IStateAdDal
    {
        public List<StateAd> GetStateAdsAllProps(string addName, string satateAge, string satateArea, string roomCount, string description, string agentCompanyName)
        {
            using (var _context = new EmlakOfisiContext())
            {
                var query = _context.StateAds.Include(x => x.User).AsQueryable();

                if (!string.IsNullOrEmpty(addName))
                {
                    query = query.Where(x => x.AdName == addName);
                }

                if (!string.IsNullOrEmpty(satateAge))
                {
                    query = query.Where(x => x.SatateAge == satateAge);
                }


                if (!string.IsNullOrEmpty(satateArea))
                {
                    query = query.Where(x => x.StateArea == satateArea);
                }

                if (!string.IsNullOrEmpty(roomCount))
                {
                    query = query.Where(x => x.RoomCount == roomCount);
                }

                if (!string.IsNullOrEmpty(description))
                {
                    query = query.Where(x => x.Description == description);
                }

                if (!string.IsNullOrEmpty(agentCompanyName))
                {
                    query = query.Where(x => x.User.AgentCompanyName == agentCompanyName);
                }

                return query.ToList();
            }
        }

        public StateAd GetStateAllPropsByStatesAdId(int id)
        {
            using (var _context = new EmlakOfisiContext())
            {
                return _context.StateAds.Where(x => x.StateId == id).Include(x => x.User).FirstOrDefault();
            }
        }
    }
}
