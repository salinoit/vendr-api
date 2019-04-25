using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class PedidoParcela
    {
        public int IdPedidoParcela { get; set; }
        public int IdPedido { get; set; }
        public int NroParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public DateTime? DataVencimento { get; set; }
        public long LastUpdate { get; set; }
        public int? IdFormaPagamento { get; set; }
        public decimal? ValorPago { get; set; }
        public DateTime? DataPagamento { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
    }
}
