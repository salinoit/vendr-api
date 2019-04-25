using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class FormaPagamentoVendedor
    {
        public int IdFormaPagamentoVendedor { get; set; }
        public int IdVendedor { get; set; }
        public int IdFormaPagamento { get; set; }
        public string Formato { get; set; }
        public decimal Valor { get; set; }
        public long? LastUpdate { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }

        public virtual FormaPagamento IdFormaPagamentoNavigation { get; set; }
        public virtual Vendedor IdVendedorNavigation { get; set; }
    }
}
