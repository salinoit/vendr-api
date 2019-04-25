using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class Despesa
    {
        public int IdDespesa { get; set; }
        public int? IdTipoDespesa { get; set; }
        public int IdVendedor { get; set; }
        public string OutroTipo { get; set; }
        public decimal? ValorDespesa { get; set; }
        public DateTime? DataVencimento { get; set; }
        public int? IdFormaPagamento { get; set; }
        public decimal? ValorPago { get; set; }
        public DateTime? DataPagamento { get; set; }
        public long? LastUpdate { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }

        public virtual FormaPagamento IdFormaPagamentoNavigation { get; set; }
        public virtual TipoDespesa IdTipoDespesaNavigation { get; set; }
        public virtual Vendedor IdVendedorNavigation { get; set; }
    }
}
