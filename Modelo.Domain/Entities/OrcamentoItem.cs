using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class OrcamentoItem
    {
        public int IdOrcamentoItem { get; set; }
        public int IdOrcamento { get; set; }
        public int IdProdutoServico { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
        public long LastUpdate { get; set; }
        public decimal Taxa { get; set; }
        public decimal? PrecoCusto { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }

        public virtual Orcamento IdOrcamentoNavigation { get; set; }
        public virtual ProdutoServico IdProdutoServicoNavigation { get; set; }
    }
}
