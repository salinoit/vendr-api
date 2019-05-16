using System;
using System.Collections.Generic;
using System.Text;

namespace Vendr.Domain.Dto
{
    public class PedidoDTO
    {

        private string _id_pedido;

        public string id_pedido {
            get
            {
                return Convert.ToInt32(_id_pedido).ToString("d6");
            }
            set
            {
                _id_pedido = value;
            }
        }

        public int id_consumidor { get; set; }

        public int id_vendedor { get; set; }

        public int id_status_pedido { get; set; }

        public string nome_consumidor { get; set; }

        public DateTime data_pedido { get; set; }

        public string status_pedido { get; set; }

        public double valor_pedido { get; set; }

        public string valor_pedido_fmt
        {
            get
            {
                return string.Format("{0:c2}", valor_pedido);
            }
        }

    }
}
