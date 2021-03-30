using Assignment.Models;
using Assignment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    [Route("server/api/gwp")]
    [ApiController]
    public class CountryGwpController : ControllerBase
    {
        private readonly ICountryGwpService countryGwpService;
        public CountryGwpController(ICountryGwpService countryGwpService)
        {
            this.countryGwpService = countryGwpService;
        }

        [HttpPost("avg")]
        public async Task<Dictionary<string,double>> GetAvgGwpAsync([FromBody] GwpAvgRequest request)
        {
            return await this.countryGwpService.GetGwpAvgAsync(request).ConfigureAwait(false);
        }
    }
}
