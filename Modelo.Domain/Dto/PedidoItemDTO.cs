using System;
using System.Collections.Generic;
using System.Text;

namespace Vendr.Domain.Dto
{
    public class PedidoItemDTO
    {


        public int id_pedido_item { get; set; }

        public int id_produto_servico { get; set; }

        public int quantidade { get; set; }

        public double preco_unitario { get; set; }

        public string descricao { get; set; }

        public double total_item
        {
            get
            {
                return preco_unitario * quantidade;
            }
        }

    }
}
