using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data;
using Vendr.Domain.Dto;
using Vendr.Domain.Interfaces;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using AutoMapper;

namespace Vendr.Infra.Data.Dapper
{
    public class UsuarioDapper : IRepository<UsuarioDto>
    {

        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public UsuarioDapper([FromServices]IConfiguration configuration, [FromServices]IMapper mapper)
        {
            _config = configuration;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(UsuarioDto obj)
        {
            throw new NotImplementedException();
        }

        public object Select(int id)
        {
            using (SqlConnection con = new SqlConnection(
             _config.GetConnectionString("DefaultConnection")))
            {
                var obj = con.QueryFirst<object>(@"SELECT * FROM vendr.usuario WHERE id_usuario=@idusuario", new { idusuario=id});
                return obj;
            };
        }

        public IList<object> List()
        {
            using (SqlConnection con = new SqlConnection(
             _config.GetConnectionString("DefaultConnection")))
            {
                var list = con.Query<object>(@"SELECT TOP 100 * FROM vendr.usuario ");
                return list.AsList();
            };

        }

        public UsuarioDto SelectAs(int id)
        {
            var t = Select(id);
            return _mapper.Map<UsuarioDto>(t);
        }

        public IList<UsuarioDto> ListAs()
        {
            var list = List();
            return _mapper.Map<IList<UsuarioDto>>(list);
            
        }

        public void Update(UsuarioDto obj)
        {
            throw new NotImplementedException();
        }
    }
}
