using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class OrcamentoParcela
    {
        public int IdOrcamentoParcela { get; set; }
        public int IdOrcamento { get; set; }
        public int NroParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public DateTime? DataVencimento { get; set; }
        public long LastUpdate { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }

        public virtual Orcamento IdOrcamentoNavigation { get; set; }
    }
}
