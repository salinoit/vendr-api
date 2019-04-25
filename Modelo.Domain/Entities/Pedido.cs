using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class Pedido
    {
        public Pedido()
        {
            Orcamento = new HashSet<Orcamento>();
            PedidoItem = new HashSet<PedidoItem>();
            PedidoParcela = new HashSet<PedidoParcela>();
        }

        public int IdPedido { get; set; }
        public int IdVendedor { get; set; }
        public int? IdConsumidor { get; set; }
        public decimal ValorPedido { get; set; }
        public decimal Desconto { get; set; }
        public int QtdeParcelas { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public long LastUpdate { get; set; }
        public string Obs { get; set; }
        public string FormaPagamento { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }
        public int Periodo { get; set; }
        public decimal? ValorFrete { get; set; }
        public int? IdPedidoAntigo { get; set; }
        public DateTime? DataCriacao { get; set; }
        public int? IdStatusPedido { get; set; }

        public virtual StatusPedido IdStatusPedidoNavigation { get; set; }
        public virtual Vendedor IdVendedorNavigation { get; set; }
        public virtual ICollection<Orcamento> Orcamento { get; set; }
        public virtual ICollection<PedidoItem> PedidoItem { get; set; }
        public virtual ICollection<PedidoParcela> PedidoParcela { get; set; }
    }
}
