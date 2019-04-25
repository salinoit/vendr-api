using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class Estoque
    {
        public int IdEstoque { get; set; }
        public int IdProdutoServico { get; set; }
        public int? IdFornecedor { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoCusto { get; set; }
        public DateTime DataRegistro { get; set; }
        public long LastUpdate { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }
        public DateTime? DataPagamento { get; set; }

        public virtual Fornecedor IdFornecedorNavigation { get; set; }
        public virtual ProdutoServico IdProdutoServicoNavigation { get; set; }
    }
}
