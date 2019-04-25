using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class StatusPedido
    {
        public StatusPedido()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int IdStatusPedido { get; set; }
        public string Descricao { get; set; }
        public long LastUpdate { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
