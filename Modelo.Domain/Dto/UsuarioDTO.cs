using System;
using System.Collections.Generic;
using System.Text;

namespace Vendr.Domain.Dto
{
    public class UsuarioDto
    {

        public int id_usuario { get; set; }

        public int id_perfil { get; set; }

        public int id_consumidor { get; set; }

        public string email { get; set; }

        public string senha { get; set; }

        public string nome { get; set; }                       

        public string fone { get; set; }

        public string foto { get; set; }

        public string endereco { get; set; }

        public string endereco_bairro { get; set; }

        public string endereco_numero { get; set; }

        public string estado { get; set; }

        public string cep { get; set; }

        public string cidade { get; set; }

        public bool ativo { get; set; }

    }
}
