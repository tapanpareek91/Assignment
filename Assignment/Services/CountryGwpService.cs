using Assignment.Models;
using Assignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Services
{
    public class CountryGwpService: ICountryGwpService
    {
        private readonly ICountryGwpRepository repo;
        public CountryGwpService(ICountryGwpRepository repo)
        {
            this.repo = repo;
        }
        public async Task<Dictionary<string, double>> GetGwpAvgAsync(GwpAvgRequest request)
        {
            return await this.repo.GetGwpAvgAsync(request).ConfigureAwait(false);
        }
    }
}
