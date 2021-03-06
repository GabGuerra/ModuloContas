﻿using ModuloContas.Models.Beneficiario;
using ModuloContas.Models.MovimentacaoTitulo;
using ModuloContas.Models.Pagamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloContas.Models.Titulo
{
    public class ContaPagarVD : TituloVD
    {
        public bool isParcelado { get { return InfoPagamento.NumParcelas > 1; } }
        public ContaPagarVD()
        {
            TituloPai = new TituloVD();
            InfoPagamento = new PagamentoVD();
            Beneficiario = new BeneficiarioVD();
            ListaMovimentacoes = new List<MovimentacaoTituloVD>();
        }
        public ContaPagarVD
        (
               long? codTitulo,
               double vlrAberto,
               double vlrOriginal,
               DateTime datVencimento,
               TituloVD tituloPai,
               PagamentoVD infoPagamento,
               List<MovimentacaoTituloVD> listaMovimentacoes,
               BeneficiarioVD beneficiario
        )
        {
                CodTitulo = codTitulo;
                VlrAberto = vlrAberto;
                VlrOriginal = vlrOriginal;
                DatVencimento = datVencimento;
                TituloPai = tituloPai;
                InfoPagamento = infoPagamento;
                ListaMovimentacoes = listaMovimentacoes;
                Beneficiario = beneficiario;
        }
    }
}
