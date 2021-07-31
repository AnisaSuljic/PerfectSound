using Microsoft.AspNetCore.Mvc;
using PerfectSound.Interfaces;
using PerfectSound.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Controllers
{
    public class ProductionCompanyController : BaseController<Model.Model.ProductionCompany,object>
    {
        public ProductionCompanyController(IService<ProductionCompany, object> service) : base(service)
        {
        }
    }
}
