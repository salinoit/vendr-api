using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Consumidor = new HashSet<Consumidor>();
            HistoricoAssinatura = new HashSet<HistoricoAssinatura>();
            UsuarioBanco = new HashSet<UsuarioBanco>();
            Vendedor = new HashSet<Vendedor>();
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Hash { get; set; }
        public string TipoUsuario { get; set; }
        public long LastUpdate { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }
        public bool? Assinante { get; set; }
        public string AssinaturaClienteId { get; set; }
        public int? AssinaturaTipo { get; set; }
        public int? AssinaturaPlano { get; set; }
        public int? AssinaturaTipoPagamento { get; set; }
        public DateTime? AssinaturaData { get; set; }
        public string AssinaturaId { get; set; }
        public string AssinaturaTipoDescricao { get; set; }
        public int? AssinaturaTipoQtdeVendedor { get; set; }

        public virtual ICollection<Consumidor> Consumidor { get; set; }
        public virtual ICollection<HistoricoAssinatura> HistoricoAssinatura { get; set; }
        public virtual ICollection<UsuarioBanco> UsuarioBanco { get; set; }
        public virtual ICollection<Vendedor> Vendedor { get; set; }
    }
}
