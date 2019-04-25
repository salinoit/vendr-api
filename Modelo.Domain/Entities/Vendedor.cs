using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class Vendedor : BaseEntity
    {
        public Vendedor()
        {
            Consumidor = new HashSet<Consumidor>();
            Despesa = new HashSet<Despesa>();
            FormaPagamentoVendedor = new HashSet<FormaPagamentoVendedor>();
            Fornecedor = new HashSet<Fornecedor>();
            MinhaCategoria = new HashSet<MinhaCategoria>();
            Orcamento = new HashSet<Orcamento>();
            Pedido = new HashSet<Pedido>();
            ProdutoServico = new HashSet<ProdutoServico>();
        }

        public int IdVendedor { get; set; }
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public string Frase { get; set; }
        public long LastUpdate { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }
        public int? IdVendedorPai { get; set; }
        public string PorOndeConheceu { get; set; }

        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consumidor> Consumidor { get; set; }
        public virtual ICollection<Despesa> Despesa { get; set; }
        public virtual ICollection<FormaPagamentoVendedor> FormaPagamentoVendedor { get; set; }
        public virtual ICollection<Fornecedor> Fornecedor { get; set; }
        public virtual ICollection<MinhaCategoria> MinhaCategoria { get; set; }
        public virtual ICollection<Orcamento> Orcamento { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
        public virtual ICollection<ProdutoServico> ProdutoServico { get; set; }
    }
}
