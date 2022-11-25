using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Repositories;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICowinRepository _cowinRepository;

        public HomeController(ILogger<HomeController> logger, ICowinRepository cowinRepository)
        {
            _logger = logger;
            _cowinRepository = cowinRepository;
        }


        public async Task<List<StateData>> GetAllStates()
        {
            return await _cowinRepository.GetAllStates();
        }


        public async Task<Districts> GetDistrictByStateId(string stateId)
        {
            return await _cowinRepository.GetDistrictByStateId(stateId);
        }


        public async Task<List<Centers>> GetCalendarByDistrict(string districtId,string date)
        {
            return await _cowinRepository.GetCalendarByDistrict(districtId, date);
        }

        public IActionResult Index()
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
