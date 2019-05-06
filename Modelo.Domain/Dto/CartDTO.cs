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
   
}
