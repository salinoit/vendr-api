using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class Log
    {
        public int IdLog { get; set; }
        public int IdUsuario { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public long LastUpdate { get; set; }
        public DateTime DataRegistro { get; set; }
        public long? LocalLastUpdate { get; set; }
    }
}
