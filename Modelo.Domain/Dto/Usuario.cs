using System;
using System.Collections.Generic;
using System.Text;

namespace Vendr.Domain.Dto
{
    public class UsuarioDto
    {

        public int id { get; set; }

        public string nome { get; set; }

        public string email { get; set; }

        public string senha { get; set; }

        public string celular { get; set; }

        public string foto { get; set; }

    }
}
