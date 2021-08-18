using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Model
{
    public class ProductionCompany
    {
        public int ProductionCompanyId { get; set; }
        public string ProductionCompanyName { get; set; }

        public override string ToString()
        {
            return ProductionCompanyName;
        }
    }
}
