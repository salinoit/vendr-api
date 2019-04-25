using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class PedidoItem
    {
        public int IdPedidoItem { get; set; }
        public int IdPedido { get; set; }
        public int IdProdutoServico { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
        public long LastUpdate { get; set; }
        public decimal Taxa { get; set; }
        public decimal? PrecoCusto { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }
        public decimal? PrecoFinal { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
        public virtual ProdutoServico IdProdutoServicoNavigation { get; set; }
    }
}
