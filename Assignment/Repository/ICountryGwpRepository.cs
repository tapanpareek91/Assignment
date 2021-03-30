using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Repository
{
    public interface ICountryGwpRepository
    {
        Task<Dictionary<string, double>> GetGwpAvgAsync(GwpAvgRequest request);
    }
}
