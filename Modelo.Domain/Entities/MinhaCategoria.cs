using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class MinhaCategoria
    {
        public MinhaCategoria()
        {
            ProdutoServico = new HashSet<ProdutoServico>();
        }

        public int IdMinhaCategoria { get; set; }
        public string Descricao { get; set; }
        public bool Produto { get; set; }
        public bool Servico { get; set; }
        public long LastUpdate { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }
        public int IdVendedor { get; set; }

        public virtual Vendedor IdVendedorNavigation { get; set; }
        public virtual ICollection<ProdutoServico> ProdutoServico { get; set; }
    }
}
