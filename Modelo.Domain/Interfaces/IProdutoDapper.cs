using System;
using System.Collections.Generic;
using System.Text;
using Vendr.Domain.Dto;

namespace Vendr.Domain.Interfaces
{
    public class ProdutoDapperPaged
    {
        public int total { get; set; }
        public IList<ProdutoDto> items { get; set; }
    }

    public interface IProdutoDapper
    {
        ProdutoDapperPaged SelectPagedAs(int page, int size, string search);
    }
}
