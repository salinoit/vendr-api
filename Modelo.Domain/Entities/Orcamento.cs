using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class Orcamento
    {
        public Orcamento()
        {
            OrcamentoItem = new HashSet<OrcamentoItem>();
            OrcamentoParcela = new HashSet<OrcamentoParcela>();
        }

        public int IdOrcamento { get; set; }
        public int IdVendedor { get; set; }
        public int? IdConsumidor { get; set; }
        public decimal ValorOrcamento { get; set; }
        public decimal Desconto { get; set; }
        public int QtdeParcelas { get; set; }
        public DateTime DataOrcamento { get; set; }
        public long LastUpdate { get; set; }
        public string Obs { get; set; }
        public string FormaPagamento { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }
        public int Periodo { get; set; }
        public decimal? ValorFrete { get; set; }
        public int? IdOrcamentoAntigo { get; set; }
        public DateTime? DataCriacao { get; set; }
        public int? IdStatusOrcamento { get; set; }
        public int? IdPedido { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
        public virtual StatusOrcamento IdStatusOrcamentoNavigation { get; set; }
        public virtual Vendedor IdVendedorNavigation { get; set; }
        public virtual ICollection<OrcamentoItem> OrcamentoItem { get; set; }
        public virtual ICollection<OrcamentoParcela> OrcamentoParcela { get; set; }
    }
}
