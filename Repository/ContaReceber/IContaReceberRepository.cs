using ModuloContas.Models.MovimentacaoTitulo;
using ModuloContas.Models.Titulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloContas.Repository.ContaReceber
{
    public interface IContaReceberRepository
    {
        public int InserirContaReceber(ContaReceberVD contaReceber);
        public void InserirMovimentacaoSubstituicao(long movimentacao);
        public void InserirMovimentacao(long codTitulo, MovimentacaoTituloVD movimentacao);
    }
}
