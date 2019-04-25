using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class Consumidor : BaseEntity
    {
        public int IdConsumidor { get; set; }
        public int? IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public int? IdVendedor { get; set; }
        public long LastUpdate { get; set; }
        public bool? Ativo { get; set; }
        public DateTime? DataRegistro { get; set; }
        public long? LocalLastUpdate { get; set; }

        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Vendedor IdVendedorNavigation { get; set; }
    }
}
