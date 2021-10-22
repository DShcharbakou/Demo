using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SomeController : ControllerBase
    {
        private readonly ISomeService _someService;

        public SomeController(ISomeService someService)
        {
            _someService = someService;
        }

        [HttpGet("adult")]
        public IEnumerable<SomeModel> GetAdultUserList()
        {
            return _someService.GetModelsWithAgeMoreThen18();
        }

        [HttpGet("young")]
        public IEnumerable<SomeModel> GetYoungUserList()
        {
            return _someService.GetModelsWithAgeLessThen18();
        }

        [HttpPost]
        public int CreateNewSomeModel([FromBody] SomeModel viewModel)
        {
            return _someService.AddAdultPerson(viewModel);
        }
    }
}
