using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class HistoricoAssinatura
    {
        public int IdHistoricoAssinatura { get; set; }
        public int? IdUsuario { get; set; }
        public int? AssinaturaTipo { get; set; }
        public int? AssinaturaPlano { get; set; }
        public int? AssinaturaTipoPagamento { get; set; }
        public DateTime? AssinaturaData { get; set; }
        public string AssinaturaId { get; set; }
        public string Status { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
