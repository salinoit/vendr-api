﻿using System;
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
            return ListAs().Where(p => p.id_usuario == id);
        }

        public IList<object> List()
        {
            using (SqlConnection con = new SqlConnection(
              _config.GetConnectionString("DefaultConnection")))
            {
                            
                var list = con.Query<object>(@"Vendr.lista_usuarios_consumidores", commandType: CommandType.StoredProcedure);
                return list.ToList();

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

        public  void Update(UsuarioDto obj)
        {
            using (SqlConnection con = new SqlConnection(
            _config.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("ID_USUARIO", obj.id_usuario.ToString());
                p.Add("ID_PERFIL", obj.id_perfil.ToString());
                p.Add("NOME", obj.nome.ToString());
                p.Add("FONE", obj.fone.ToString());
                p.Add("SENHA", obj.senha.ToString());

                //p.Add("TYPE", exibitionType.ToString());
                //p.Add("SEARCH", search == null ? "" : search);
                //p.Add("VENDEDOR", vendedor.ToString());
                //p.Add("MYCOUNT", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var result = con.Query<object>(@"Vendr.atualiza_usuario_consumidor", p, commandType: CommandType.StoredProcedure);
            };
        }
    }
}
