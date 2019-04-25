using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class FormaPagamento
    {
        public FormaPagamento()
        {
            Despesa = new HashSet<Despesa>();
            FormaPagamentoVendedor = new HashSet<FormaPagamentoVendedor>();
        }

        public int IdFormaPagamento { get; set; }
        public string Descricao { get; set; }
        public DateTime DataRegistro { get; set; }
        public long LastUpdate { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }

        public virtual ICollection<Despesa> Despesa { get; set; }
        public virtual ICollection<FormaPagamentoVendedor> FormaPagamentoVendedor { get; set; }
    }
}
