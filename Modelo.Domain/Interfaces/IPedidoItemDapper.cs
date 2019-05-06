using System;
using System.Collections.Generic;
using System.Text;
using Vendr.Domain.Dto;

namespace Vendr.Domain.Interfaces
{
   

    public interface IPedidoItemDApper
    {
        IList<PedidoItemDTO> ListAs(int id_pedido);

       PedidoItemDTO  SelectAs(int id,int id_pedido);
    }
}
