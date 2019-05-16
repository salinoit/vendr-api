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
                var p = new DynamicParameters();
                p.Add("ID_VENDEDOR", id);
                var obj = con.QueryFirst<object>(@"vendr.web_lista_vendedor",p,commandType:CommandType.StoredProcedure);

                return obj;
            };
        }

        public IList<object> List()
        {
            using (SqlConnection con = new SqlConnection(
             _config.GetConnectionString("DefaultConnection")))
            {
                var list = con.Query<object>(@"vendr.web_lista_vendedor",commandType:CommandType.StoredProcedure);
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
