using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModuloContas.Models.Titulo;
using ModuloContas.Services.ContaPagar;

namespace ModuloContas.Controllers.ContaPagar
{
    [ApiController]
    public class ContaPagarController : Controller
    {
        private readonly IContaPagarService _contaPagarServices;
        public ContaPagarController(IContaPagarService contaPagarService)
        {
            _contaPagarServices = contaPagarService;
        }

        [Route("api/[controller]/[action]")]
        [HttpPost]
        public JsonResult InserirContaPagar([FromBody]ContaPagarVD conta)         
        {
            return Json(_contaPagarServices.InserirContaPagar(conta));
        }
    }
}