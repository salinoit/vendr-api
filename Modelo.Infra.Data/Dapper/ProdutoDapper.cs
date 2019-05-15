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
                    ).ForMember(
                        dest => dest.preco_venda_fmt,
                        opt => opt.MapFrom(src => src.preco_venda_fmt)
                    ).ForMember(
                        dest => dest.Html,
                        opt => opt.MapFrom(src => src.html)
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
                       
            ProdutoDapperPaged tmp = new ProdutoDapperPaged();

            using (SqlConnection con = new SqlConnection(
             _config.GetConnectionString("DefaultConnection")))
            {
                
                var p = new DynamicParameters();
                p.Add("PAGINA", page.ToString());
                p.Add("TAMANHO", size.ToString());
                p.Add("ORDER", order.ToString());
                p.Add("TYPE", exibitionType.ToString());
                p.Add("SEARCH", search==null  ? "":search);
                p.Add("VENDEDOR", vendedor.ToString());
                p.Add("MYCOUNT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                //p.Add("c", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);                
                var list = con.Query<object>(@"Vendr.web_searchbar_produto", p, commandType: CommandType.StoredProcedure);
                tmp.total = Convert.ToInt32(p.Get<int>("MYCOUNT"));
                var before= _mapper.Map<IList<ProdutoDtoDapper>>(list);
               
                tmp.items= _mapper.Map<IList<ProdutoDto>>(before);
            };

            return tmp;
        }

    }
}
