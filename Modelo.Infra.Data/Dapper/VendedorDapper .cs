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
    public class VendedorDapper : IRepository<VendedorDto>
    {
       
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public VendedorDapper([FromServices]IConfiguration configuration, [FromServices]IMapper mapper)
        {
            _config = configuration;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(VendedorDto obj)
        {
            throw new NotImplementedException();
        }

        public object Select(int id)
        {
            using (SqlConnection con = new SqlConnection(
             _config.GetConnectionString("DefaultConnection")))
            {
                var obj = con.QueryFirst<object>(@"SELECT V.id_vendedor,P.nome, P.email,P.foto V.id_perfil FROM vendr.vendedor V inner join vendr.perfil P on V.id_perfil=P.id_perfil  WHERE V.id_vendedor=@id", new { id=id});

                return obj;
            };
        }

        public IList<object> List()
        {
            using (SqlConnection con = new SqlConnection(
             _config.GetConnectionString("DefaultConnection")))
            {
                var list = con.Query<object>(@"SELECT V.id_vendedor,P.nome, P.email, V.id_perfil FROM vendr.vendedor V inner join vendr.perfil P on V.id_perfil=P.id_perfil  ");
                return list.AsList();
            };

        }

        public VendedorDto SelectAs(int id)
        {
            try
            {
                var t = Select(id);                
                return _mapper.Map<VendedorDto>(t);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public IList<VendedorDto> ListAs()
        {
            var list = List();
            return _mapper.Map<IList<VendedorDto>>(list);
            
        }

        public void Update(VendedorDto obj)
        {
            throw new NotImplementedException();
        }


    }
}
