using System;
using System.Collections.Generic;

namespace Vendr.Domain.Entities
{
    public partial class Perfil : BaseEntity
    {
        public Perfil()
        {
            Consumidor = new HashSet<Consumidor>();
            Fornecedor = new HashSet<Fornecedor>();
            Vendedor = new HashSet<Vendedor>();
        }

        public int IdPerfil { get; set; }
        public string Foto { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CpfCnpj { get; set; }
        public string Fone { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string EnderecoNumero { get; set; }
        public string EnderecoBairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public long LastUpdate { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool? Ativo { get; set; }
        public long? LocalLastUpdate { get; set; }
        public string Observacao { get; set; }

        public virtual ICollection<Consumidor> Consumidor { get; set; }
        public virtual ICollection<Fornecedor> Fornecedor { get; set; }
        public virtual ICollection<Vendedor> Vendedor { get; set; }
    }
}
