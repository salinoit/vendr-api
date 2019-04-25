using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class StatusOrcamento
    {
        public StatusOrcamento()
        {
            Orcamento = new HashSet<Orcamento>();
        }

        public int IdStatusOrcamento { get; set; }
        public string Descricao { get; set; }
        public long LastUpdate { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Orcamento> Orcamento { get; set; }
    }
}
