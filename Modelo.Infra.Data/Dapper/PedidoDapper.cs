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
    public class PedidoDapper : IRepository<PedidoDTO>
    {

        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public PedidoDapper([FromServices]IConfiguration configuration, [FromServices]IMapper mapper)
        {
            _config = configuration;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(PedidoDTO obj)
        {
            using (SqlConnection con = new SqlConnection(
          _config.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("EMAIL", obj.id_consumidor.ToString());              

              //  p.Add("MSG","", dbType: DbType.String, direction: ParameterDirection.Output,size:50);

                try
                {
                    con.Execute(@"Vendr.criar_usuario_consumidor", p, commandType: CommandType.StoredProcedure);
                }
                catch(Exception po)
                {
                    var err = po.Message;
                }

                var ret = Convert.ToString(p.Get<string>("MSG"));

                if  (ret=="EXIST")
                {
                    throw new Exception("Usuário já cadastrado!");
                }
            };
        }

        public object Select(int id)
        {
            return ListAs().Where(p => p.id_pedido == id);
        }

        public IList<object> List()
        {
            using (SqlConnection con = new SqlConnection(
              _config.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("ID_CONSUMIDOR", "0");

                var list = con.Query<object>(@"Vendr.web_pedidos",p, commandType: CommandType.StoredProcedure);
                return list.ToList();

            };
        }

        public PedidoDTO SelectAs(int id)
        {
            var t = Select(id);
            return _mapper.Map<PedidoDTO>(t);
        }

        public IList<PedidoDTO> ListAs()
        {
            var list = List();
            return _mapper.Map<IList<PedidoDTO>>(list);
            
        }

        public  void Update(PedidoDTO obj)
        {
            
        }
    }
}
