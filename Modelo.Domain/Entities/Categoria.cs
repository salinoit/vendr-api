using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class Categoria
    {
        public Categoria()
        {
            ProdutoServico = new HashSet<ProdutoServico>();
        }

        public int IdCategoria { get; set; }
        public int? IdCategoriaPai { get; set; }
        public string Descricao { get; set; }
        public bool Produto { get; set; }
        public bool Servico { get; set; }
        public long LastUpdate { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }

        public virtual ICollection<ProdutoServico> ProdutoServico { get; set; }
    }
}
