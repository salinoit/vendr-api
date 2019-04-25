using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            Estoque = new HashSet<Estoque>();
        }

        public int IdFornecedor { get; set; }
        public int IdVendedor { get; set; }
        public int IdPerfil { get; set; }
        public long LastUpdate { get; set; }
        public bool? Ativo { get; set; }
        public DateTime? DataRegistro { get; set; }
        public long? LocalLastUpdate { get; set; }

        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual Vendedor IdVendedorNavigation { get; set; }
        public virtual ICollection<Estoque> Estoque { get; set; }
    }
}
