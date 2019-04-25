using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class ProdutoServico
    {
        public ProdutoServico()
        {
            Estoque = new HashSet<Estoque>();
            OrcamentoItem = new HashSet<OrcamentoItem>();
            PedidoItem = new HashSet<PedidoItem>();
        }

        public int IdProdutoServico { get; set; }
        public int IdVendedor { get; set; }
        public int IdCategoria { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string CodigoBarras { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoCusto { get; set; }
        public int QuantidadeInicialEstoque { get; set; }
        public bool Visivel { get; set; }
        public DateTime DataRegistro { get; set; }
        public long LastUpdate { get; set; }
        public bool? Ativo { get; set; }
        public string Fabricante { get; set; }
        public decimal? Lucro { get; set; }
        public string ImagemProduto { get; set; }
        public long? LocalLastUpdate { get; set; }
        public string Observacao { get; set; }
        public int? ComissaoPercentAvista { get; set; }
        public int? ComissaoPercentParcelada { get; set; }
        public int? IdMinhaCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual MinhaCategoria IdMinhaCategoriaNavigation { get; set; }
        public virtual Vendedor IdVendedorNavigation { get; set; }
        public virtual ICollection<Estoque> Estoque { get; set; }
        public virtual ICollection<OrcamentoItem> OrcamentoItem { get; set; }
        public virtual ICollection<PedidoItem> PedidoItem { get; set; }
    }
}
