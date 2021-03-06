﻿using ModuloContas.Models.Beneficiario;
using ModuloContas.Models.MovimentacaoTitulo;
using ModuloContas.Models.Pagamento;
using ModuloContas.Models.Sacado;
using System;
using System.Collections.Generic;

namespace ModuloContas.Models.Titulo
{
    public class TituloVD
    {
        public long? CodTitulo { get; set; }
        public double VlrAberto { get; set; }
        public double VlrOriginal { get; set; }
        public DateTime DatVencimento { get; set; }
        public TituloVD TituloPai { get; set; }
        public PagamentoVD InfoPagamento { get; set; }
        public List<MovimentacaoTituloVD> ListaMovimentacoes { get; set; }
        public BeneficiarioVD Beneficiario { get; set; }
        public SacadoVD Sacado { get; set; }

        public TituloVD()
        {
            TituloPai = new TituloVD();
            InfoPagamento = new PagamentoVD();
            Beneficiario = new BeneficiarioVD();     
            ListaMovimentacoes = new List<MovimentacaoTituloVD>();
            Sacado = new SacadoVD();
        }       
        public TituloVD
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
