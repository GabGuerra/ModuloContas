using ModuloContas.Models.MovimentacaoTitulo;
using ModuloContas.Models.Resultado;
using ModuloContas.Models.Titulo;
using ModuloContas.Repository.ContaReceber;
using ModuloContas.Services.ContaPagar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloContas.Services.ContaReceber
{
    public class ContaReceberService: IContaReceberService, ITituloServices<ContaReceberVD>
    {
        private readonly IContaReceberRepository _contaReceberRepository;

        public ContaReceberService(IContaReceberRepository contaReceberRepository)
        {
            _contaReceberRepository = contaReceberRepository;
        }
        public ResultadoVD ProcessarContaReceber(ContaReceberVD contaReceber)
        {
            ResultadoVD resultado = new ResultadoVD(true);
            InserirTitulo(contaReceber);

            try
            {
                if (contaReceber.isParcelado)
                {
                    ProcessarPagamentoParcelado(contaReceber);
                    _contaReceberRepository.InserirMovimentacaoSubstituicao(contaReceber.CodTitulo.Value);
                }
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = $"Não foi possível inserir a conta. {Environment.NewLine} {ex.Message}";
            }

            return resultado;
        }
        public void InserirTitulo(ContaReceberVD contaReceber)
        {
            try
            {
                contaReceber.CodTitulo = _contaReceberRepository.InserirContaReceber(contaReceber);
            }
            catch
            {
                throw;
            }
        }

        public void ProcessarPagamentoParcelado(ContaReceberVD contaPai)
        {
            for (int i = 1; i <= contaPai.InfoPagamento.NumParcelas; i++)
            {
                var vlrParcela = contaPai.VlrOriginal / contaPai.InfoPagamento.NumParcelas;
                var contaReceber = new ContaReceberVD
                    (
                        null,
                        vlrParcela,
                        vlrParcela,
                        contaPai.DatVencimento.AddMonths(i),
                        contaPai,
                        contaPai.InfoPagamento,
                        new List<MovimentacaoTituloVD>(),
                        contaPai.Sacado
                    );

                _contaReceberRepository.InserirContaReceber(contaReceber);
            }
        }

        public ResultadoVD InserirMovimentacao(long codTitulo, MovimentacaoTituloVD movimentacao)
        {
            ResultadoVD resultado = new ResultadoVD(true);
            try
            {
                _contaReceberRepository.InserirMovimentacao(codTitulo, movimentacao);
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = $"Não foi possível inserir a conta. {Environment.NewLine} {ex.Message}";
            }

            return resultado;
        }
    }
}
