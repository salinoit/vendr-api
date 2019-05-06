﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vendr.Domain.Dto
{
    public class PedidoDTO
    {

        public int id_pedido { get; set; }

        public int id_consumidor { get; set; }

        public int id_vendedor { get; set; }

        public int id_status_pedido { get; set; }

        public string nome_consumidor { get; set; }

        public DateTime data_pedido { get; set; }

        public string status_pedido { get; set; }

    }
}
