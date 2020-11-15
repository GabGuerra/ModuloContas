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
    [Route("api/[controller]/[action]")]
    public class ContaPagarController : Controller
    {
        private readonly IContaPagarService _contaPagarServices;        
        public ContaPagarController(IContaPagarService contaPagarService)
        {
            _contaPagarServices = contaPagarService;
        }
        
        [HttpPost]
        public JsonResult ProcessarContaPagar(object contaAux)         
        {
            ContaPagarVD conta = contaAux as ContaPagarVD;
            return Json(_contaPagarServices.ProcessarContaPagar(conta));
        }
    }
}