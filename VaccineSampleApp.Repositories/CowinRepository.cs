using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Models;
using WebApplication5.Middlewares;

namespace WebApp.Repositories
{
    public class CowinRepository : ICowinRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemoryCache _memoryCache;

        public CowinRepository(IHttpClientFactory httpClientFactory, IMemoryCache memoryCache)
        {
            _httpClientFactory = httpClientFactory;
            _memoryCache = memoryCache;
        }

        public async Task<List<StateData>> GetAllStates()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                client.BaseAddress = new Uri("https://cdn-api.co-vin.in/api/v2/admin/location/states");

                client.DefaultRequestHeaders.Add("Accept-Language", "hi_IN");

                var result = await client.GetStringAsync("");

                var response = JsonConvert.DeserializeObject<States>(result).states.ToList();

                return response;

            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
        }

        public async Task<Districts> GetDistrictByStateId(string stateId)
        {
            try
            {
                Districts districtCache;
                bool isExist = _memoryCache.TryGetValue(stateId, out districtCache);
                if (!isExist)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(365));
                    var client = _httpClientFactory.CreateClient();

                    client.BaseAddress = new Uri(string.Format("https://cdn-api.co-vin.in/api/v2/admin/location/districts/{0}", stateId));

                    client.DefaultRequestHeaders.Add("Accept-Language", "hi_IN");

                    var result = await client.GetStringAsync("");

                    districtCache = JsonConvert.DeserializeObject<Districts>(result);
                    _memoryCache.Set(stateId, districtCache, cacheEntryOptions);
                }

                return districtCache;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
        }

        public async Task<List<Centers>> GetCalendarByDistrict(string districtId, string date)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                client.BaseAddress = new Uri(string.Format("https://cdn-api.co-vin.in/api/v2/appointment/sessions/public/calendarByDistrict?precaution_flag=true&district_id={0}&date={1}&vaccine=COVISHIELD", districtId, date));

                client.DefaultRequestHeaders.Add("Accept-Language", "hi_IN");

                var result = await client.GetStringAsync("");

                var centersData = JsonConvert.DeserializeObject<CentersData>(result);

                return centersData.centers.ToList();
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
        }
    }
}