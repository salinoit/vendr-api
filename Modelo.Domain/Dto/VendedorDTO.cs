using System;
using System.Collections.Generic;
using System.Text;

namespace Vendr.Domain.Dto
{
    public class VendedorDto
    {

        public int id_vendedor { get; set; }

        public int id_perfil { get; set; }

        public string nome { get; set; }

        public string email { get; set; }

        public string foto { get; set; }

    }
}
