using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class GwpAvgRequest
    {
        public GwpAvgRequest()
        {
            this.LineOfBusiness = new List<string>();
        }
        public string Country { get; set; }
        public IList<string> LineOfBusiness { get; set; }
    }
}
