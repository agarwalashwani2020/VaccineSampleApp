using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using VaccineSampleApp.CommonService;
using VaccineSampleApp.Repositories;
using WebApp.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {

        //private ICommonService _machineIdProvider;
        //public MyWonderfulController(IMachineIdProvider machineIdProvider)
        //{
        //    this._machineIdProvider = machineIdProvider;
        //}

        private readonly ICowinRepository _cowinRepository;

        public HomeController(ICowinRepository cowinRepository)
        {
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
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
