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
    public class PedidoDapper : IRepository<PedidoDTO>,IPedidoDapper
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

        public IList<PedidoDTO> List(int idConsumidor)
        {
            using (SqlConnection con = new SqlConnection(
              _config.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("ID_CONSUMIDOR", idConsumidor);

                var list = con.Query<object>(@"Vendr.web_lista_pedido", p, commandType: CommandType.StoredProcedure);

                return _mapper.Map<IList<PedidoDTO>>(list);
                
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
