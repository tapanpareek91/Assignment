using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Services
{
    public interface ICountryGwpService
    {
        Task<Dictionary<string, double>> GetGwpAvgAsync(GwpAvgRequest request);
    }
}
