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
    public class ProdutoDapper : IRepository<ProdutoDto>, IProdutoDapper
    {

        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<ProdutoDtoDapper, ProdutoDto>()
                    .ForMember(
                        dest => dest.Descricao,
                        opt => opt.MapFrom(src => src.descricao)
                    )
                     .ForMember(
                        dest => dest.IdProdutoServico,
                        opt => opt.MapFrom(src => src.id_produto_servico)
                    )
                     .ForMember(
                        dest => dest.Tipo,
                        opt => opt.MapFrom(src => src.tipo)
                    )
                     .ForMember(
                        dest => dest.PrecoVenda,
                        opt => opt.MapFrom(src => src.preco_venda)
                    );
            }
        }


        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public ProdutoDapper([FromServices]IConfiguration configuration, [FromServices]IMapper mapper)
        {
            _config = configuration;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProdutoDto obj)
        {
            throw new NotImplementedException();
        }

        public object Select(int id)
        {
            using (SqlConnection con = new SqlConnection(
             _config.GetConnectionString("DefaultConnection")))
            {
                var obj = con.QueryFirst<object>(@"SELECT * FROM vendr.produtoservico WHERE id_produtoservico=@id", new { id=id});
                return obj;
            };
        }

        public IList<object> List()
        {
            using (SqlConnection con = new SqlConnection(
             _config.GetConnectionString("DefaultConnection")))
            {
                var list = con.Query<object>(@"SELECT TOP 100 * FROM vendr.produtoservico ");
                return list.AsList();
            };

        }

        public ProdutoDto SelectAs(int id)
        {
            var t = Select(id);
            return _mapper.Map<ProdutoDto>(t);
        }

        public IList<ProdutoDto> ListAs()
        {
            var list = List();
            return _mapper.Map<IList<ProdutoDto>>(list);
            
        }

        public void Update(ProdutoDto obj)
        {
            throw new NotImplementedException();
        }

        public ProdutoDapperPaged SelectPagedAs(int page,int size, string search)
        {
            string clausure = " WHERE 1=1 ";
            string searchTherm = "";
            if (!string.IsNullOrEmpty(search))
            {
                searchTherm = " AND descricao LIKE '%" + search + "%'";
                clausure += searchTherm;
            }
            

            int skip = ((page - 1) * size);
            ProdutoDapperPaged tmp = new ProdutoDapperPaged();

            using (SqlConnection con = new SqlConnection(
             _config.GetConnectionString("DefaultConnection")))
            {

                var qtd = con.ExecuteScalar(@"SELECT COUNT(*) AS TOTAL FROM vendr.produto_servico " + clausure);
                var list = con.Query<object>(@"SELECT  * FROM vendr.produto_servico " + clausure + " ORDER BY (SELECT NULL) OFFSET " + skip.ToString() + " ROWS FETCH NEXT " + size.ToString() + " ROWS ONLY");
                tmp.total = Convert.ToInt32(qtd);

                var before= _mapper.Map<IList<ProdutoDtoDapper>>(list);
                tmp.items= _mapper.Map<IList<ProdutoDto>>(before);
            };

            return tmp;
        }

    }
}
