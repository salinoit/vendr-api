using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class TipoDespesa
    {
        public TipoDespesa()
        {
            Despesa = new HashSet<Despesa>();
        }

        public int IdTipoDespesa { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataRegistro { get; set; }
        public long? LastUpdate { get; set; }
        public bool? Ativo { get; set; }

        public virtual ICollection<Despesa> Despesa { get; set; }
    }
}
