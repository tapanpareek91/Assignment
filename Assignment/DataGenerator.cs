using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CountryGwpContext(
                serviceProvider.GetRequiredService<DbContextOptions<CountryGwpContext>>()))
            {
                // Look for any board games.
                if (context.CountryGwpItems.Any())
                {
                    return;   // Data was already seeded
                }

                context.CountryGwpItems.AddRange(LoadCountryGwpItems());

                context.SaveChanges();
            }
        }

        private static List<CountryGwp> LoadCountryGwpItems()
        {
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            var lst = new List<CountryGwp>();
            using (StreamReader sr = new StreamReader(@".\SeedData\gwpByCountry.csv"))
            {
                string[] headers = sr.ReadLine().Split(',');
                int i = 1;
                while (!sr.EndOfStream)
                {
                    string[] rows = CSVParser.Split(sr.ReadLine());
                    CountryGwp countryGwp = new CountryGwp();
                    countryGwp.Id = i;
                    countryGwp.Country = rows[0].Replace("\"", string.Empty);
                    countryGwp.VariableId = rows[1].Replace("\"", string.Empty);
                    countryGwp.VariableName = rows[2].Replace("\"", string.Empty);
                    countryGwp.LineOfBusiness = rows[3].Replace("\"", string.Empty);
                    countryGwp.Y2000 = string.IsNullOrEmpty(rows[4]) ? 0 : Convert.ToDouble(rows[4]);
                    countryGwp.Y2001 = string.IsNullOrEmpty(rows[5]) ? 0 : Convert.ToDouble(rows[5]);
                    countryGwp.Y2002 = string.IsNullOrEmpty(rows[6]) ? 0 : Convert.ToDouble(rows[6]);
                    countryGwp.Y2003 = string.IsNullOrEmpty(rows[7]) ? 0 : Convert.ToDouble(rows[7]);
                    countryGwp.Y2004 = string.IsNullOrEmpty(rows[8]) ? 0 : Convert.ToDouble(rows[8]);
                    countryGwp.Y2005 = string.IsNullOrEmpty(rows[9]) ? 0 : Convert.ToDouble(rows[9]);
                    countryGwp.Y2006 = string.IsNullOrEmpty(rows[10]) ? 0 : Convert.ToDouble(rows[10]);
                    countryGwp.Y2007 = string.IsNullOrEmpty(rows[11]) ? 0 : Convert.ToDouble(rows[11]);
                    countryGwp.Y2008 = string.IsNullOrEmpty(rows[12]) ? 0 : Convert.ToDouble(rows[12]);
                    countryGwp.Y2009 = string.IsNullOrEmpty(rows[13]) ? 0 : Convert.ToDouble(rows[13]);
                    countryGwp.Y2010 = string.IsNullOrEmpty(rows[14]) ? 0 : Convert.ToDouble(rows[14]);
                    countryGwp.Y2011 = string.IsNullOrEmpty(rows[15]) ? 0 : Convert.ToDouble(rows[15]);
                    countryGwp.Y2012 = string.IsNullOrEmpty(rows[16]) ? 0 : Convert.ToDouble(rows[16]);
                    countryGwp.Y2013 = string.IsNullOrEmpty(rows[17]) ? 0 : Convert.ToDouble(rows[17]);
                    countryGwp.Y2014 = string.IsNullOrEmpty(rows[18]) ? 0 : Convert.ToDouble(rows[18]);
                    countryGwp.Y2015 = string.IsNullOrEmpty(rows[19]) ? 0 : Convert.ToDouble(rows[19]);

                    lst.Add(countryGwp);
                    i++;
                }
            }

            return lst;
        }
    }
}
