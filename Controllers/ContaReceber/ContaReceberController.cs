using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModuloContas.Models.Titulo;
using ModuloContas.Services.ContaReceber;

namespace ModuloContas.Controllers.ContaReceber
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ContaReceberController : Controller
    {
        private readonly IContaReceberService _contaReceberServices;
        public ContaReceberController(IContaReceberService contaReceberService)
        {
            _contaReceberServices = contaReceberService;
        }

        [HttpPost]
        public JsonResult ProcessarContaReceber(object contaAux)
        {
            ContaReceberVD conta = contaAux as ContaReceberVD;
            return Json(_contaReceberServices.ProcessarContaReceber(conta));
        }
    }
}