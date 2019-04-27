using System;
using System.Collections.Generic;
using System.Text;

namespace Vendr.Domain.Dto
{
    public class CartDto
    {
        public double total { get; set; }
        public string total_fmt { get; set; }
        public List<CartItemDto> items { get; set; }

        public CartDto()
        {
            items = new List<CartItemDto>();
        }
    }
    public class CartItemDto
    {
        public int qtd { get; set; }
        public ProdutoDto produto { get; set; }
    }



    public class CartQueryDto
    {
        public IEnumerable<CartQueryItemDto> existentes { get; set; }
        public CartQueryItemDto novo { get; set; }
    }

    public class CartQueryItemDto
    {
        public int id { get; set; }
        public int qtd { get; set; }
    }
}
