using ModuloContas.Models.MovimentacaoTitulo;
using ModuloContas.Models.Resultado;
using ModuloContas.Models.Titulo;

namespace ModuloContas.Services.ContaPagar
{
    public interface ITituloServices<T> where T : TituloVD
    {
        public void InserirTitulo(T titulo);
        public ResultadoVD InserirMovimentacao(long codTitulo, MovimentacaoTituloVD movimentacao);
    }
}