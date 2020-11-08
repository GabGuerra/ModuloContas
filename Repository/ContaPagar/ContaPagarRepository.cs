using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ModuloContas.Models.Titulo;
using ModuloContas.Repository.Shared;
using MySql.Data.MySqlClient;

namespace ModuloContas.Repository.ContaPagar
{
    public class ContaPagarRepository : MySqlRepository<ContaPagarVD>, IContaPagarRepository
    {
        public ContaPagarRepository(IConfiguration config) : base(config) { }
        public void InserirContaPagar(ContaPagarVD conta)
        {
            var sql = @"INSERT INTO TITULO
                            (
                                COD_TITULO,
                                VLR_ABERTO,
                                VLR_ORIGINAL,
                                DAT_VENCIMENTO,
                                COD_PEDIDO,
                                COD_BENEFICIARIO,
                                COD_TIPO_TITULO,
                                COD_TITULO_PAI
                             )
				        VALUES
                             (
                               @COD_TITULO,
                               @VLR_ABERTO,
                               @VLR_ORIGINAL,
                               @DAT_VENCIMENTO
                               @COD_PEDIDO,
                               @COD_BENEFICIARIO,
                               @COD_TIPO_TITULO,
                               @COD_TITULO_PAI
                             )";
            using (var cmd = new MySqlCommand(sql))
            {
                

                ExecutarComando(cmd);
            }
        }
    }
}
