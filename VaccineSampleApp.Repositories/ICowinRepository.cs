using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repositories
{
    public interface ICowinRepository
    {
        Task<List<StateData>> GetAllStates();
        Task<Districts> GetDistrictByStateId(string stateId);
        Task<List<Centers>> GetCalendarByDistrict(string districtId, string date);
    }
}
