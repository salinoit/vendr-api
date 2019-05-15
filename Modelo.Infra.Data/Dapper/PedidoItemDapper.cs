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
    public class PedidoItemDapper : IRepository<PedidoItemDTO>,IPedidoItemDApper
    {

        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public PedidoItemDapper([FromServices]IConfiguration configuration, [FromServices]IMapper mapper)
        {
            _config = configuration;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(PedidoItemDTO obj)
        {
           
        }

        public object Select(int id,int id_pedido)
        {
            return ListAs(id_pedido).Where(p => p.id_pedido_item == id);
        }

        public IList<object> List(int id_pedido)
        {
            using (SqlConnection con = new SqlConnection(
              _config.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("ID_PEDIDO", id_pedido.ToString());

                var list = con.Query<object>(@"Vendr.web_lista_pedido_item", p, commandType: CommandType.StoredProcedure);
                return list.ToList();

            };
        }

        public PedidoItemDTO SelectAs(int id, int id_pedido)
        {
            var t = Select(id,id_pedido);
            return _mapper.Map<PedidoItemDTO>(t);
        }

        public IList<PedidoItemDTO> ListAs(int id_pedido)
        {
            var list = List(id_pedido);
            return _mapper.Map<IList<PedidoItemDTO>>(list);
            
        }

        public  void Update(PedidoItemDTO obj)
        {
            
        }

        public object Select(int id)
        {
            throw new NotImplementedException();
        }

        public PedidoItemDTO SelectAs(int id)
        {
            throw new NotImplementedException();
        }

        public IList<object> List()
        {
            throw new NotImplementedException();
        }

        public IList<PedidoItemDTO> ListAs()
        {
            throw new NotImplementedException();
        }

    }
}
