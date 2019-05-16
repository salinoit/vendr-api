using System;
using System.Collections.Generic;
using System.Text;

namespace Vendr.Domain.Dto
{
    public class VendedorDto
    {

        private string _data_registo;

        public int id_vendedor { get; set; }

        public int id_perfil { get; set; }

        public string nome { get; set; }

        public string email { get; set; }

        public string data_registro
        {
            get
            {
                return Convert.ToDateTime(_data_registo).ToShortDateString();
            }
            set
            {
                _data_registo = value;
            }
        }

        public string cpf_cnpj { get; set; }

        public string cep { get; set; }

        public string endereco { get; set; }

        public string endereco_numero { get; set; }

        public string cidade { get; set; }

        public string estado { get; set; }

        public string foto { get; set; }

    }
}
