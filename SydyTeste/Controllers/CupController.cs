using Microsoft.AspNetCore.Mvc;
using SydyTeste.Data.Models;
using SydyTeste.Data.Services.Interfaces;

namespace SydyTeste.API.Controllers
{
    [Route("api/Campeonato")]
    [ApiController]
    public class CupController : ControllerBase
    {
        private readonly ICupService _cupService;
        public CupController(ICupService cupService)
        {
            _cupService = cupService;
        }

        [HttpGet]
        public ActionResult<Cup> GetCup()
        {
            return _cupService.GetCup();
        }
    }
}
