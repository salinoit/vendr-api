using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class UsuarioBanco
    {
        public int IdBancoUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdBanco { get; set; }
        public string Agencia { get; set; }
        public string TipoConta { get; set; }
        public string Conta { get; set; }
        public string Extra { get; set; }
        public long LastUpdate { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }

        public virtual Banco IdBancoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
