using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Repository
{
    public class CountryGwpRepository : ICountryGwpRepository
    {
        private readonly CountryGwpContext dbContext;
        public CountryGwpRepository(CountryGwpContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Dictionary<string, double>> GetGwpAvgAsync(GwpAvgRequest request)
        {
            var op = new Dictionary<string, double>();
            var data = dbContext.CountryGwpItems.Where(x => x.Country == request.Country);
            foreach (var lob in request.LineOfBusiness)
            {
                op.Add(lob, data.Where(x => x.LineOfBusiness == lob).Select(x => ( x.Y2008 + x.Y2009 + x.Y2010 + x.Y2011 + x.Y2012 + x.Y2013 + x.Y2014 + x.Y2015)/8).FirstOrDefault());
            }

            return op;
        }
    }
}
