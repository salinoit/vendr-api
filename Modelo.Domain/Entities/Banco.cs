using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class Banco
    {
        public Banco()
        {
            UsuarioBanco = new HashSet<UsuarioBanco>();
        }

        public int IdBanco { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public long LastUpdate { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }

        public virtual ICollection<UsuarioBanco> UsuarioBanco { get; set; }
    }
}
