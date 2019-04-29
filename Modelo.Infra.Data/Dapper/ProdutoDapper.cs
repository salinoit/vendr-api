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
                        dest => dest.ImagemProduto,
                        opt => opt.MapFrom(src => src.imagem_produto)
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
                var obj = con.QueryFirst<object>(@"SELECT * FROM vendr.produto_servico WHERE id_produto_servico=@id", new { id=id});

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
            try
            {
                var t = Select(id);
                var before = _mapper.Map<ProdutoDtoDapper>(t);
                return _mapper.Map<ProdutoDto>(before);
            }
            catch(Exception ex)
            {
                return null;
            }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page">Página de visualização</param>
        /// <param name="size">Tamanho da página</param>
        /// <param name="search">Opcional: barra de pesquisa - string</param>
        /// <param name="order">Padrão=0 - Preço menor para o maior</param>
        /// <param name="exibitionType">Padrao=0 (ordem de cadastro), 1 novos itens, 2 mais vendidos, 3 ja comprados, 4 favoritos</param>
        /// <returns></returns>
        public ProdutoDapperPaged SelectPagedAs(int page,int size, string search, int order = 0, int exibitionType = 0, int vendedor=0)
        {
            string clausure = " WHERE 1=1 ";
            string searchTherm = "";
            if (!string.IsNullOrEmpty(search))
            {
                searchTherm = " AND descricao LIKE '%" + search + "%'";
                clausure += searchTherm;
            }
            if (vendedor>0)
            {
                searchTherm = " AND id_vendedor=" + vendedor.ToString(); 
                clausure += searchTherm;
            }

            string sort = "(SELECT NULL)"; //pra nao permitir ordem, mas tem que ter isso por causa do fetch next

            //if (order==0)
            //{
            //    sort = "preco_venda";
            //}
            //else if (order==1)
            //{
            //    sort = "preco_venda desc";
            //}


            int skip = ((page - 1) * size);
            ProdutoDapperPaged tmp = new ProdutoDapperPaged();

            using (SqlConnection con = new SqlConnection(
             _config.GetConnectionString("DefaultConnection")))
            {

                var qtd = con.ExecuteScalar(@"SELECT COUNT(*) AS TOTAL FROM vendr.produto_servico " + clausure);
                var list = con.Query<object>(@"SELECT  * FROM vendr.produto_servico " + clausure + " ORDER BY " + sort + " OFFSET " + skip.ToString() + " ROWS FETCH NEXT " + size.ToString() + " ROWS ONLY");
                tmp.total = Convert.ToInt32(qtd);

                var before= _mapper.Map<IList<ProdutoDtoDapper>>(list);
                tmp.items= _mapper.Map<IList<ProdutoDto>>(before);
            };

            return tmp;
        }

    }
}
