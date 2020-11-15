using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ModuloContas.Enums;
using ModuloContas.Models.MovimentacaoTitulo;
using ModuloContas.Models.Titulo;
using ModuloContas.Repository.Shared;
using MySql.Data.MySqlClient;

namespace ModuloContas.Repository.ContaPagar
{
    public class ContaPagarRepository :  MySqlRepository<ContaPagarVD>, IContaPagarRepository
    {
        public ContaPagarRepository(IConfiguration config) : base(config) { }
        public int InserirContaPagar(ContaPagarVD conta)
        {
            var sql = @"CALL PROC_INSERE_TITULO
                            (
                                @_VLR_ABERTO,
                                @_VLR_ORIGINAL,
                                @_DAT_VENCIMENTO,
                                @_COD_PEDIDO,
                                @_COD_BENEFICIARIO,
                                @_COD_TIPO_TITULO,
                                @_COD_TITULO_PAI,
                                @_VLR_DESCONTO,
                                @_VLR_JUROS,
                                @_VLR_MULTA,
                                @_COD_TIPO_MOVI_TITULO
                            )";

            var movimentacao = conta.ListaMovimentacoes.Where(x => x.TipoMovimentacao == TipoMovimentacao.Abertura).FirstOrDefault();
            using (var cmd = new MySqlCommand(sql))
            {

                cmd.Parameters.AddWithValue("@_VLR_ABERTO", conta.VlrAberto);
                cmd.Parameters.AddWithValue("@_VLR_ORIGINAL", conta.VlrOriginal);
                cmd.Parameters.AddWithValue("@_DAT_VENCIMENTO", conta.DatVencimento);                
                cmd.Parameters.AddWithValue("@_COD_BENEFICIARIO", null);
                cmd.Parameters.AddWithValue("@_COD_TIPO_TITULO", TipoTitulo.Pagar);
                cmd.Parameters.AddWithValue("@_COD_TITULO_PAI", conta.TituloPai.CodTitulo);
                cmd.Parameters.AddWithValue("@_VLR_DESCONTO", movimentacao.VlrDesconto);
                cmd.Parameters.AddWithValue("@_VLR_JUROS", movimentacao.VlrJuros);
                cmd.Parameters.AddWithValue("@_VLR_MULTA", movimentacao.VlrMulta);
                cmd.Parameters.AddWithValue("@_COD_TIPO_MOVI_TITULO", TipoMovimentacao.Abertura);
                cmd.Parameters.Add("PCOD_TITULO", MySqlDbType.Int32).Direction = System.Data.ParameterDirection.Output;
                return ExecutarComando(cmd);
            }
        }

        //TODO: Passar movimentação de substituição para método genérico 
        public void InserirMovimentacaoSubstituicao(long codTitulo)
        {
            var sql = @"INSERT INTO MOVIMENTACAO_TITULO 
                            (DAT_MOVIMENTACAO, COD_TITULO, COD_TIPO_MOVI_TITULO)
                        VALUES                 
                            (CURDATE(), @COD_TITULO, @COD_TIPO_MOVI_TITULO)";

            using (var cmd = new MySqlCommand(sql))
            {                
                cmd.Parameters.AddWithValue("@COD_TITULO", codTitulo);
                cmd.Parameters.AddWithValue("@COD_TIPO_MOVI_TITULO", TipoMovimentacao.Substituicao); 
                ExecutarComando(cmd);
            }

        }

        public void InserirMovimentacao(long codTitulo, MovimentacaoTituloVD movimentacao) 
        {
            var sql = @"INSERT INTO MOVIMENTACAO_TITULO 
                            (DAT_MOVIMENTACAO, COD_TITULO, COD_TIPO_MOVI_TITULO, VLR_MOVIMENTACAO, VLR_DESCONTO, VLR_JUROS, VLR_MULTA)
                        VALUES                 
                            (CURDATE(), @COD_TITULO, @COD_TIPO_MOVI_TITULO, @VLR_MOVIMENTACAO, @VLR_DESCONTO, @VLR_JUROS, @VLR_MULTA)";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@COD_TITULO", codTitulo);
                cmd.Parameters.AddWithValue("@COD_TIPO_MOVI_TITULO", movimentacao.TipoMovimentacao.GetHashCode());
                cmd.Parameters.AddWithValue("@VLR_MOVIMENTACAO", movimentacao.VlrMovimentacao);
                cmd.Parameters.AddWithValue("@VLR_DESCONTO", movimentacao.VlrDesconto);
                cmd.Parameters.AddWithValue("@VLR_JUROS", movimentacao.VlrJuros);
                cmd.Parameters.AddWithValue("@VLR_MULTA", movimentacao.VlrMovimentacao);

                ExecutarComando(cmd);
            }
        }
    }
}
