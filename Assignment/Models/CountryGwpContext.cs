using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class CountryGwpContext : DbContext
    {
        public CountryGwpContext(DbContextOptions<CountryGwpContext> options) : base(options)
        {
           // this.LoadCountryGwpItems();
        }

        public DbSet<CountryGwp> CountryGwpItems { get; set; }
    }
}
