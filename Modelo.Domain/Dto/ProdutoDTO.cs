using System;
using System.Collections.Generic;
using System.Text;

namespace Vendr.Domain.Dto
{
    public class ProdutoDto
    {
        public int IdProdutoServico { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public string ImagemProduto { get; set; }
        public string preco_venda_fmt
        {
            get
            {
                return string.Format("{0:c2}", PrecoVenda);
            }
        }
    }

}

    public class ProdutoDtoDapper
    {
        public int id_produto_servico { get; set; }
        public string tipo { get; set; }
        public string descricao { get; set; }
        public decimal preco_venda { get; set; }
        public string imagem_produto { get; set; }
        public string preco_venda_fmt
        {
            get
            {
                return string.Format("{0:c2}", preco_venda);
            }
        }
    }

