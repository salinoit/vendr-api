using System;
using System.Collections.Generic;
using System.Text;
using Vendr.Domain.Dto;

namespace Vendr.Domain.Interfaces
{

    public interface IPedidoDapper
    {
        IList<PedidoDTO> List(int idConsumidor);
    }
}
