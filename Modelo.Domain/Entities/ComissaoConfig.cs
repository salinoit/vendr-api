using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class ComissaoConfig
    {
        public int IdComissaoConfig { get; set; }
        public bool? IsProduto { get; set; }
        public bool? IsFaturamento { get; set; }
        public int? FaturamentoDe1 { get; set; }
        public int? FaturamentoAte1 { get; set; }
        public int? FaturamentoPercent1 { get; set; }
        public int? FaturamentoDe2 { get; set; }
        public int? FaturamentoAte2 { get; set; }
        public int? FaturamentoPercent2 { get; set; }
        public int? FaturamentoDe3 { get; set; }
        public int? FaturamentoAte3 { get; set; }
        public int? FaturamentoPercent3 { get; set; }
        public long LastUpdate { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }
        public int IdUsuario { get; set; }
    }
}
