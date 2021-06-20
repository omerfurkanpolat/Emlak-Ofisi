using EmalkOfisi.AgentUI.Models;
using EmlakOfisi.Business.Abstract;
using EmlakOfisi.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmalkOfisi.AgentUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStateAdService _stateAdService;
        public HomeController(ILogger<HomeController> logger, IStateAdService stateAdService)
        {
            _logger = logger;
            _stateAdService = stateAdService;
        }

        public IActionResult Index(StateSearchViewModel searchModel)
        {
            searchModel.StateAds = _stateAdService.GetAllStateAds(searchModel.AddName, searchModel.StateAge, searchModel.StateArea, searchModel.RoomCount, searchModel.Description, searchModel.AgentCompanyName);

            return View(searchModel);
        }

        public IActionResult GetStateAdsDetail(int id)
        {
            StateAd state = _stateAdService.GetStateAllPropsByStateAdId(id);
            StateAdDetailViewModel model = new StateAdDetailViewModel()
            {
                AdName = state.AdName,
                AgentCompanyName = state.User.AgentCompanyName,
                Description = state.Description,
                RoomCount = state.RoomCount,
                SatateAge = state.SatateAge,
                StateArea = state.StateArea,


            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
