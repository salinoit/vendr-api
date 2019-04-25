using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer;
using Vendr.Domain.Entities;

namespace Vendr.Infra.Data.Context
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banco> Banco { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<ComissaoConfig> ComissaoConfig { get; set; }
        public virtual DbSet<Consumidor> Consumidor { get; set; }
        public virtual DbSet<Despesa> Despesa { get; set; }
        public virtual DbSet<Estoque> Estoque { get; set; }
        public virtual DbSet<FormaPagamento> FormaPagamento { get; set; }
        public virtual DbSet<FormaPagamentoVendedor> FormaPagamentoVendedor { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<HistoricoAssinatura> HistoricoAssinatura { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<MinhaCategoria> MinhaCategoria { get; set; }
        public virtual DbSet<Orcamento> Orcamento { get; set; }
        public virtual DbSet<OrcamentoItem> OrcamentoItem { get; set; }
        public virtual DbSet<OrcamentoParcela> OrcamentoParcela { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<PedidoItem> PedidoItem { get; set; }
        public virtual DbSet<PedidoParcela> PedidoParcela { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<ProdutoServico> ProdutoServico { get; set; }
        public virtual DbSet<StatusOrcamento> StatusOrcamento { get; set; }
        public virtual DbSet<StatusPedido> StatusPedido { get; set; }
        public virtual DbSet<TipoDespesa> TipoDespesa { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioBanco> UsuarioBanco { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=198.38.85.100,51433;Database=CD_163513_Vendr_HML;user=vendrhml2019;password=vendr@2019");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Banco>(entity =>
            {
                entity.HasKey(e => e.IdBanco)
                    .HasName("PK__banco__70BD16423ABF4965");

                entity.ToTable("banco", "vendr");

                entity.Property(e => e.IdBanco).HasColumnName("id_banco");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("codigo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DataRegistro)
                    .HasColumnName("data_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__categori__CD54BC5ACB6D2516");

                entity.ToTable("categoria", "vendr");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasColumnName("ativo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DataRegistro)
                    .HasColumnName("data_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategoriaPai).HasColumnName("id_categoria_pai");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.Produto).HasColumnName("produto");

                entity.Property(e => e.Servico).HasColumnName("servico");
            });

            modelBuilder.Entity<ComissaoConfig>(entity =>
            {
                entity.HasKey(e => e.IdComissaoConfig)
                    .HasName("PK__Comissao_config");

                entity.ToTable("comissao_config", "vendr");

                entity.Property(e => e.IdComissaoConfig).HasColumnName("id_comissao_config");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.DataRegistro)
                    .HasColumnName("data_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.FaturamentoAte1).HasColumnName("faturamento_ate1");

                entity.Property(e => e.FaturamentoAte2).HasColumnName("faturamento_ate2");

                entity.Property(e => e.FaturamentoAte3).HasColumnName("faturamento_ate3");

                entity.Property(e => e.FaturamentoDe1).HasColumnName("faturamento_de1");

                entity.Property(e => e.FaturamentoDe2).HasColumnName("faturamento_de2");

                entity.Property(e => e.FaturamentoDe3).HasColumnName("faturamento_de3");

                entity.Property(e => e.FaturamentoPercent1).HasColumnName("faturamento_percent1");

                entity.Property(e => e.FaturamentoPercent2).HasColumnName("faturamento_percent2");

                entity.Property(e => e.FaturamentoPercent3).HasColumnName("faturamento_percent3");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IsFaturamento).HasColumnName("is_faturamento");

                entity.Property(e => e.IsProduto).HasColumnName("is_produto");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");
            });

            modelBuilder.Entity<Consumidor>(entity =>
            {
                entity.HasKey(e => e.IdConsumidor)
                    .HasName("PK__tmp_cons__111C62890719EF58");

                entity.ToTable("consumidor", "vendr");

                entity.HasIndex(e => new { e.IdPerfil, e.IdVendedor })
                    .HasName("ix_dm_vendr_consumidor_id_vendedor");

                entity.HasIndex(e => new { e.IdVendedor, e.Ativo })
                    .HasName("ix_dm_vendr_consumidor_id_vendedor_ativo");

                entity.HasIndex(e => new { e.IdConsumidor, e.IdVendedor, e.IdPerfil })
                    .HasName("ix_dm_vendr_consumidor_id_perfil_Inc");

                entity.HasIndex(e => new { e.IdConsumidor, e.IdPerfil, e.IdVendedor, e.Ativo })
                    .HasName("IX_consumidor_ativo_001");

                entity.HasIndex(e => new { e.IdConsumidor, e.IdUsuario, e.IdPerfil, e.Ativo })
                    .HasName("IX_consumidor_ativo_002");

                entity.HasIndex(e => new { e.IdConsumidor, e.IdUsuario, e.IdPerfil, e.Ativo, e.DataRegistro, e.LocalLastUpdate, e.IdVendedor, e.LastUpdate })
                    .HasName("ix_dm_vendr_consumidor_id_vendedor_last_update");

                entity.Property(e => e.IdConsumidor).HasColumnName("id_consumidor");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasColumnName("ativo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DataRegistro)
                    .HasColumnName("data_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Consumidor)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__consumido__id_pe__503BEA1C");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Consumidor)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__tmp_consu__id_us__3F115E1A");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Consumidor)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK__tmp_consu__id_ve__3E1D39E1");
            });

            modelBuilder.Entity<Despesa>(entity =>
            {
                entity.HasKey(e => e.IdDespesa);

                entity.ToTable("despesa", "vendr");

                entity.HasIndex(e => new { e.IdDespesa, e.IdTipoDespesa, e.OutroTipo, e.ValorDespesa, e.DataVencimento, e.IdFormaPagamento, e.ValorPago, e.DataPagamento, e.LastUpdate, e.LocalLastUpdate, e.IdVendedor, e.Ativo })
                    .HasName("ix_dm_vendr_despesa_id_vendedor_ativo");

                entity.Property(e => e.IdDespesa).HasColumnName("id_despesa");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.DataPagamento)
                    .HasColumnName("data_pagamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataVencimento)
                    .HasColumnName("data_vencimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdFormaPagamento).HasColumnName("id_forma_pagamento");

                entity.Property(e => e.IdTipoDespesa).HasColumnName("id_tipo_despesa");

                entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.OutroTipo)
                    .HasColumnName("outro_tipo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ValorDespesa)
                    .HasColumnName("valor_despesa")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ValorPago)
                    .HasColumnName("valor_pago")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdFormaPagamentoNavigation)
                    .WithMany(p => p.Despesa)
                    .HasForeignKey(d => d.IdFormaPagamento)
                    .HasConstraintName("FK_despesa_forma_pagamento");

                entity.HasOne(d => d.IdTipoDespesaNavigation)
                    .WithMany(p => p.Despesa)
                    .HasForeignKey(d => d.IdTipoDespesa)
                    .HasConstraintName("FK_despesa_tipo_despesa");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Despesa)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_despesa_vendedor");
            });

            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.HasKey(e => e.IdEstoque)
                    .HasName("PK__estoque__A3D2521CE2A2E4E4");

                entity.ToTable("estoque", "vendr");

                entity.HasIndex(e => e.DataPagamento);

                entity.HasIndex(e => new { e.IdFornecedor, e.Ativo, e.DataPagamento });

                entity.HasIndex(e => new { e.IdFornecedor, e.Quantidade, e.Ativo, e.DataPagamento })
                    .HasName("ix_md_estoque_ativo_data_pagamento");

                entity.HasIndex(e => new { e.IdEstoque, e.IdFornecedor, e.Quantidade, e.PrecoCusto, e.DataRegistro, e.Ativo, e.LocalLastUpdate, e.DataPagamento, e.IdProdutoServico, e.LastUpdate })
                    .HasName("ix_dm_vendr_estoque_id_produto_servico_last_update");

                entity.Property(e => e.IdEstoque).HasColumnName("id_estoque");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.DataPagamento)
                    .HasColumnName("data_pagamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataRegistro)
                    .HasColumnName("data_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");

                entity.Property(e => e.IdProdutoServico).HasColumnName("id_produto_servico");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.PrecoCusto)
                    .HasColumnName("preco_custo")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.Estoque)
                    .HasForeignKey(d => d.IdFornecedor)
                    .HasConstraintName("FK__estoque__id_forn__160F4887");

                entity.HasOne(d => d.IdProdutoServicoNavigation)
                    .WithMany(p => p.Estoque)
                    .HasForeignKey(d => d.IdProdutoServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__estoque__id_prod__151B244E");
            });

            modelBuilder.Entity<FormaPagamento>(entity =>
            {
                entity.HasKey(e => e.IdFormaPagamento)
                    .HasName("PK__forma_pa__8EF48E1B6122A6CB");

                entity.ToTable("forma_pagamento", "vendr");

                entity.Property(e => e.IdFormaPagamento).HasColumnName("id_forma_pagamento");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasColumnName("ativo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DataRegistro)
                    .HasColumnName("data_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");
            });

            modelBuilder.Entity<FormaPagamentoVendedor>(entity =>
            {
                entity.HasKey(e => e.IdFormaPagamentoVendedor)
                    .HasName("PK_format_pagamento_vendedor");

                entity.ToTable("forma_pagamento_vendedor", "vendr");

                entity.Property(e => e.IdFormaPagamentoVendedor).HasColumnName("id_forma_pagamento_vendedor");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Formato)
                    .IsRequired()
                    .HasColumnName("formato")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.IdFormaPagamento).HasColumnName("id_forma_pagamento");

                entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdFormaPagamentoNavigation)
                    .WithMany(p => p.FormaPagamentoVendedor)
                    .HasForeignKey(d => d.IdFormaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_forma_pagamento_vendedor_forma_pagamento");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.FormaPagamentoVendedor)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_forma_pagamento_vendedor_vendedor");
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.HasKey(e => e.IdFornecedor)
                    .HasName("PK__forneced__6C477092C1F9A450");

                entity.ToTable("fornecedor", "vendr");

                entity.HasIndex(e => e.IdPerfil)
                    .HasName("ix_md_fornecedor_id_perfil");

                entity.HasIndex(e => new { e.IdPerfil, e.IdVendedor })
                    .HasName("ix_dm_vendr_fornecedor_id_vendedor");

                entity.HasIndex(e => new { e.IdVendedor, e.Ativo })
                    .HasName("ix_dm_vendr_fornecedor_id_vendedor_ativo");

                entity.HasIndex(e => new { e.IdFornecedor, e.IdPerfil, e.Ativo, e.DataRegistro, e.LocalLastUpdate, e.IdVendedor, e.LastUpdate })
                    .HasName("ix_dm_vendr_fornecedor_id_vendedor_last_update");

                entity.HasIndex(e => new { e.IdFornecedor, e.IdVendedor, e.IdPerfil, e.Ativo, e.DataRegistro, e.LocalLastUpdate, e.LastUpdate })
                    .HasName("ix_dm_vendr_fornecedor_last_update");

                entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasColumnName("ativo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DataRegistro)
                    .HasColumnName("data_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Fornecedor)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fornecedo__id_pe__4F47C5E3");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Fornecedor)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fornecedo__id_ve__1AD3FDA4");
            });

            modelBuilder.Entity<HistoricoAssinatura>(entity =>
            {
                entity.HasKey(e => e.IdHistoricoAssinatura);

                entity.ToTable("historico_assinatura", "vendr");

                entity.Property(e => e.IdHistoricoAssinatura).HasColumnName("id_historico_assinatura");

                entity.Property(e => e.AssinaturaData)
                    .HasColumnName("assinatura_data")
                    .HasColumnType("datetime");

                entity.Property(e => e.AssinaturaId)
                    .HasColumnName("assinatura_id")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AssinaturaPlano).HasColumnName("assinatura_plano");

                entity.Property(e => e.AssinaturaTipo).HasColumnName("assinatura_tipo");

                entity.Property(e => e.AssinaturaTipoPagamento).HasColumnName("assinatura_tipo_pagamento");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.HistoricoAssinatura)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_historico_assinatura_usuario");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.IdLog)
                    .HasName("PK__log__6CC851FE639507A2");

                entity.ToTable("log", "vendr");

                entity.HasIndex(e => new { e.IdUsuario, e.DataRegistro })
                    .HasName("IX_log_data_registro");

                entity.Property(e => e.IdLog).HasColumnName("id_log");

                entity.Property(e => e.DataRegistro)
                    .HasColumnName("data_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MinhaCategoria>(entity =>
            {
                entity.HasKey(e => e.IdMinhaCategoria)
                    .HasName("PK__minha_ca__832C98609C55BFE5");

                entity.ToTable("minha_categoria", "vendr");

                entity.Property(e => e.IdMinhaCategoria).HasColumnName("id_minha_categoria");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.DataRegistro)
                    .HasColumnName("data_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.Produto).HasColumnName("produto");

                entity.Property(e => e.Servico).HasColumnName("servico");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.MinhaCategoria)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__minha_categoria__id_ve__114A936A");
            });

            modelBuilder.Entity<Orcamento>(entity =>
            {
                entity.HasKey(e => e.IdOrcamento)
                    .HasName("PK__orcamento__6FF0148901ED781E");

                entity.ToTable("orcamento", "vendr");

                entity.Property(e => e.IdOrcamento).HasColumnName("id_orcamento");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.DataCriacao)
                    .HasColumnName("data_criacao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataOrcamento)
                    .HasColumnName("data_orcamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.Desconto)
                    .HasColumnName("desconto")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FormaPagamento)
                    .HasColumnName("forma_pagamento")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdConsumidor).HasColumnName("id_consumidor");

                entity.Property(e => e.IdOrcamentoAntigo).HasColumnName("id_orcamento_antigo");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.IdStatusOrcamento).HasColumnName("id_status_orcamento");

                entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.Obs)
                    .HasColumnName("obs")
                    .IsUnicode(false);

                entity.Property(e => e.Periodo)
                    .HasColumnName("periodo")
                    .HasDefaultValueSql("((30))");

                entity.Property(e => e.QtdeParcelas).HasColumnName("qtde_parcelas");

                entity.Property(e => e.ValorFrete)
                    .HasColumnName("valor_frete")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ValorOrcamento)
                    .HasColumnName("valor_orcamento")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.Orcamento)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("FK__orcamento__id_pedido");

                entity.HasOne(d => d.IdStatusOrcamentoNavigation)
                    .WithMany(p => p.Orcamento)
                    .HasForeignKey(d => d.IdStatusOrcamento)
                    .HasConstraintName("FK__orcamento__id_status_orcamento");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Orcamento)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orcamento__id_vende__18EBB532");
            });

            modelBuilder.Entity<OrcamentoItem>(entity =>
            {
                entity.HasKey(e => e.IdOrcamentoItem)
                    .HasName("PK__orcament__02C59E5D178F151C");

                entity.ToTable("orcamento_item", "vendr");

                entity.HasIndex(e => new { e.IdOrcamentoItem, e.LastUpdate, e.Ativo, e.IdProdutoServico })
                    .HasName("IX_orcamento_item_id_produto_servico");

                entity.HasIndex(e => new { e.IdProdutoServico, e.Quantidade, e.PrecoUnitario, e.Desconto, e.Taxa, e.PrecoCusto, e.IdOrcamento, e.Ativo })
                    .HasName("IX_MD_orcamento_item_id_orcamento_ativo_inc");

                entity.HasIndex(e => new { e.IdOrcamentoItem, e.IdOrcamento, e.IdProdutoServico, e.Quantidade, e.PrecoUnitario, e.Desconto, e.Taxa, e.PrecoCusto, e.Ativo, e.LocalLastUpdate, e.LastUpdate })
                    .HasName("IX_MD_orcamento_item_last_update");

                entity.Property(e => e.IdOrcamentoItem).HasColumnName("id_orcamento_item");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Desconto)
                    .HasColumnName("desconto")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IdOrcamento).HasColumnName("id_orcamento");

                entity.Property(e => e.IdProdutoServico).HasColumnName("id_produto_servico");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.PrecoCusto)
                    .HasColumnName("preco_custo")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PrecoUnitario)
                    .HasColumnName("preco_unitario")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.Taxa)
                    .HasColumnName("taxa")
                    .HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdOrcamentoNavigation)
                    .WithMany(p => p.OrcamentoItem)
                    .HasForeignKey(d => d.IdOrcamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orcamento_it__id_pe__1F98B2C1");

                entity.HasOne(d => d.IdProdutoServicoNavigation)
                    .WithMany(p => p.OrcamentoItem)
                    .HasForeignKey(d => d.IdProdutoServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orcamento_it__id_pr__208CD6FA");
            });

            modelBuilder.Entity<OrcamentoParcela>(entity =>
            {
                entity.HasKey(e => e.IdOrcamentoParcela)
                    .HasName("PK__orcamento_p__27C3F10900FE05A4");

                entity.ToTable("orcamento_parcela", "vendr");

                entity.Property(e => e.IdOrcamentoParcela).HasColumnName("id_orcamento_parcela");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.DataVencimento)
                    .HasColumnName("data_vencimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdOrcamento).HasColumnName("id_orcamento");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.NroParcela).HasColumnName("nro_parcela");

                entity.Property(e => e.ValorParcela)
                    .HasColumnName("valor_parcela")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdOrcamentoNavigation)
                    .WithMany(p => p.OrcamentoParcela)
                    .HasForeignKey(d => d.IdOrcamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orcamento_pa__id_pe__1CBC4616");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__pedido__6FF0148901ED781E");

                entity.ToTable("pedido", "vendr");

                entity.HasIndex(e => e.IdPedidoAntigo);

                entity.HasIndex(e => new { e.IdConsumidor, e.Ativo });

                entity.HasIndex(e => new { e.IdVendedor, e.DataPedido });

                entity.HasIndex(e => new { e.IdVendedor, e.IdPedido })
                    .HasName("ix_dm_vendr_pedido_id_vendedor_id_pedido");

                entity.HasIndex(e => new { e.IdVendedor, e.IdPedidoAntigo });

                entity.HasIndex(e => new { e.IdVendedor, e.LocalLastUpdate })
                    .HasName("IX_MD_pedido_id_vendedor_local_last_update");

                entity.HasIndex(e => new { e.IdPedido, e.Ativo, e.DataPedido })
                    .HasName("IX_pedido_ativo_data_pedido");

                entity.HasIndex(e => new { e.IdPedido, e.IdVendedor, e.Ativo })
                    .HasName("IX_pedido_ativo");

                entity.HasIndex(e => new { e.IdPedido, e.IdConsumidor, e.Obs, e.FormaPagamento, e.IdVendedor, e.Ativo, e.DataPedido })
                    .HasName("ix_md_pedido_id_vendedor_ativo_data_pedido");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.DataCancelamento)
                    .HasColumnName("data_cancelamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataCriacao)
                    .HasColumnName("data_criacao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataPedido)
                    .HasColumnName("data_pedido")
                    .HasColumnType("datetime");

                entity.Property(e => e.Desconto)
                    .HasColumnName("desconto")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FormaPagamento)
                    .HasColumnName("forma_pagamento")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdConsumidor).HasColumnName("id_consumidor");

                entity.Property(e => e.IdPedidoAntigo).HasColumnName("id_pedido_antigo");

                entity.Property(e => e.IdStatusPedido).HasColumnName("id_status_pedido");

                entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.Obs)
                    .HasColumnName("obs")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Periodo)
                    .HasColumnName("periodo")
                    .HasDefaultValueSql("((30))");

                entity.Property(e => e.QtdeParcelas).HasColumnName("qtde_parcelas");

                entity.Property(e => e.ValorFrete)
                    .HasColumnName("valor_frete")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ValorPedido)
                    .HasColumnName("valor_pedido")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdStatusPedidoNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdStatusPedido)
                    .HasConstraintName("FK__pedido__id_status_pedido");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pedido__id_vende__18EBB532");
            });

            modelBuilder.Entity<PedidoItem>(entity =>
            {
                entity.HasKey(e => e.IdPedidoItem)
                    .HasName("PK__pedido_i__D9F18BE31473FD8A");

                entity.ToTable("pedido_item", "vendr");

                entity.HasIndex(e => e.PrecoFinal)
                    .HasName("ix_md_pedido_item_preco_final");

                entity.HasIndex(e => new { e.IdProdutoServico, e.Ativo });

                entity.HasIndex(e => new { e.IdPedidoItem, e.IdProdutoServico, e.Quantidade, e.PrecoUnitario, e.Desconto, e.Taxa, e.PrecoCusto, e.Ativo, e.IdPedido })
                    .HasName("ix_dm_vendr_pedido_item_ativo_id_pedido");

                entity.HasIndex(e => new { e.IdPedidoItem, e.IdPedido, e.IdProdutoServico, e.Quantidade, e.PrecoUnitario, e.Desconto, e.Taxa, e.PrecoCusto, e.Ativo, e.LocalLastUpdate, e.LastUpdate })
                    .HasName("ix_dm_vendr_pedido_item_last_update");

                entity.HasIndex(e => new { e.IdPedidoItem, e.IdProdutoServico, e.Quantidade, e.PrecoUnitario, e.Desconto, e.Taxa, e.PrecoCusto, e.Ativo, e.LocalLastUpdate, e.IdPedido, e.LastUpdate })
                    .HasName("ix_dm_vendr_pedido_item_id_pedido_last_update");

                entity.Property(e => e.IdPedidoItem).HasColumnName("id_pedido_item");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Desconto)
                    .HasColumnName("desconto")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.IdProdutoServico).HasColumnName("id_produto_servico");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.PrecoCusto)
                    .HasColumnName("preco_custo")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PrecoFinal)
                    .HasColumnName("preco_final")
                    .HasColumnType("numeric(38, 2)")
                    .HasComputedColumnSql("((CONVERT([decimal](19,0),[quantidade])*[preco_unitario]-[desconto])+[taxa])");

                entity.Property(e => e.PrecoUnitario)
                    .HasColumnName("preco_unitario")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.Taxa)
                    .HasColumnName("taxa")
                    .HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PedidoItem)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pedido_it__id_pe__1F98B2C1");

                entity.HasOne(d => d.IdProdutoServicoNavigation)
                    .WithMany(p => p.PedidoItem)
                    .HasForeignKey(d => d.IdProdutoServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pedido_it__id_pr__208CD6FA");
            });

            modelBuilder.Entity<PedidoParcela>(entity =>
            {
                entity.HasKey(e => e.IdPedidoParcela)
                    .HasName("PK__pedido_p__27C3F10900FE05A4");

                entity.ToTable("pedido_parcela", "vendr");

                entity.HasIndex(e => new { e.DataPagamento, e.Ativo, e.DataVencimento });

                entity.HasIndex(e => new { e.IdPedido, e.NroParcela, e.Ativo, e.ValorPago, e.DataPagamento })
                    .HasName("IX_pedido_parcela_ativo_valor_pago_data_pagamento");

                entity.HasIndex(e => new { e.IdPedido, e.NroParcela, e.ValorParcela, e.Ativo, e.DataVencimento })
                    .HasName("IX_pedido_parcela_ativo_data_vencimento");

                entity.HasIndex(e => new { e.IdPedidoParcela, e.IdPedido, e.NroParcela, e.ValorParcela, e.DataVencimento, e.LastUpdate, e.IdFormaPagamento, e.ValorPago, e.DataPagamento, e.LocalLastUpdate, e.Ativo })
                    .HasName("ix_dm_vendr_pedido_parcela_ativo");

                entity.HasIndex(e => new { e.IdPedidoParcela, e.NroParcela, e.ValorParcela, e.DataVencimento, e.LastUpdate, e.IdFormaPagamento, e.ValorPago, e.DataPagamento, e.LocalLastUpdate, e.IdPedido, e.Ativo })
                    .HasName("ix_dm_vendr_pedido_parcela_id_pedido_ativo");

                entity.Property(e => e.IdPedidoParcela).HasColumnName("id_pedido_parcela");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.DataPagamento)
                    .HasColumnName("data_pagamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataVencimento)
                    .HasColumnName("data_vencimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdFormaPagamento).HasColumnName("id_forma_pagamento");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.NroParcela).HasColumnName("nro_parcela");

                entity.Property(e => e.ValorPago)
                    .HasColumnName("valor_pago")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ValorParcela)
                    .HasColumnName("valor_parcela")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PedidoParcela)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pedido_pa__id_pe__1CBC4616");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PK__tmp_ms_x__1D1C876897D90961");

                entity.ToTable("perfil", "vendr");

                entity.HasIndex(e => e.Email);

                entity.HasIndex(e => e.LocalLastUpdate)
                    .HasName("ix_md_perfil_local_last_update");

                entity.HasIndex(e => e.Nome)
                    .HasName("ix_md_vendr_perfil_nome");

                entity.HasIndex(e => new { e.IdPerfil, e.DataRegistro })
                    .HasName("IX_perfil_data_registro");

                entity.HasIndex(e => new { e.IdPerfil, e.Nome })
                    .HasName("ix_md_perfil");

                entity.HasIndex(e => new { e.IdPerfil, e.Nome, e.Email, e.Fone, e.DataRegistro })
                    .HasName("IX_perfil_data_registro_inc");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Cep)
                    .HasColumnName("cep")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasColumnName("cidade")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CpfCnpj)
                    .HasColumnName("cpf_cnpj")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DataRegistro)
                    .HasColumnName("data_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .HasColumnName("endereco")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoBairro)
                    .HasColumnName("endereco_bairro")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoNumero)
                    .HasColumnName("endereco_numero")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fone)
                    .HasColumnName("fone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao)
                    .HasColumnName("observacao")
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProdutoServico>(entity =>
            {
                entity.HasKey(e => e.IdProdutoServico)
                    .HasName("PK__produto___5A196F037EBB5DB7");

                entity.ToTable("produto_servico", "vendr");

                entity.HasIndex(e => e.CodigoBarras);

                entity.HasIndex(e => e.Descricao);

                entity.HasIndex(e => e.IdMinhaCategoria);

                entity.HasIndex(e => new { e.IdProdutoServico, e.Descricao, e.CodigoBarras, e.PrecoCusto, e.QuantidadeInicialEstoque, e.ImagemProduto, e.IdVendedor, e.Tipo, e.Ativo })
                    .HasName("ix_dm_vendr_produto_servico_id_vendedor_tipo_ativo+1");

                entity.HasIndex(e => new { e.IdProdutoServico, e.IdCategoria, e.Descricao, e.CodigoBarras, e.PrecoVenda, e.PrecoCusto, e.QuantidadeInicialEstoque, e.ImagemProduto, e.IdVendedor, e.Tipo, e.Ativo })
                    .HasName("ix_dm_vendr_produto_servico_id_vendedor_tipo_ativo_2");

                entity.HasIndex(e => new { e.IdProdutoServico, e.IdCategoria, e.Tipo, e.Descricao, e.CodigoBarras, e.PrecoVenda, e.PrecoCusto, e.QuantidadeInicialEstoque, e.Visivel, e.DataRegistro, e.Ativo, e.Fabricante, e.Lucro, e.ImagemProduto, e.LocalLastUpdate, e.Observacao, e.ComissaoPercentAvista, e.ComissaoPercentParcelada, e.IdVendedor, e.LastUpdate })
                    .HasName("ix_dm_vendr_produto_servico_id_vendedor_last_update");

                entity.HasIndex(e => new { e.IdProdutoServico, e.IdCategoria, e.Tipo, e.Descricao, e.CodigoBarras, e.PrecoVenda, e.PrecoCusto, e.QuantidadeInicialEstoque, e.Visivel, e.DataRegistro, e.LastUpdate, e.Fabricante, e.Lucro, e.ImagemProduto, e.LocalLastUpdate, e.Observacao, e.ComissaoPercentAvista, e.ComissaoPercentParcelada, e.IdVendedor, e.Ativo })
                    .HasName("ix_dm_vendr_produto_servico_id_vendedor_ativo");

                entity.Property(e => e.IdProdutoServico).HasColumnName("id_produto_servico");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasColumnName("ativo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CodigoBarras)
                    .HasColumnName("codigo_barras")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ComissaoPercentAvista).HasColumnName("comissao_percent_avista");

                entity.Property(e => e.ComissaoPercentParcelada).HasColumnName("comissao_percent_parcelada");

                entity.Property(e => e.DataRegistro)
                    .HasColumnName("data_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Fabricante)
                    .HasColumnName("fabricante")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.IdMinhaCategoria).HasColumnName("id_minha_categoria");

                entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");

                entity.Property(e => e.ImagemProduto)
                    .HasColumnName("imagem_produto")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.Lucro)
                    .HasColumnName("lucro")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Observacao)
                    .HasColumnName("observacao")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PrecoCusto)
                    .HasColumnName("preco_custo")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PrecoVenda)
                    .HasColumnName("preco_venda")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.QuantidadeInicialEstoque).HasColumnName("quantidade_inicial_estoque");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Visivel).HasColumnName("visivel");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.ProdutoServico)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__produto_s__id_ca__31B762FC");

                entity.HasOne(d => d.IdMinhaCategoriaNavigation)
                    .WithMany(p => p.ProdutoServico)
                    .HasForeignKey(d => d.IdMinhaCategoria)
                    .HasConstraintName("FK__ps__id_mc");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.ProdutoServico)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__produto_s__id_ve__114A936A");
            });

            modelBuilder.Entity<StatusOrcamento>(entity =>
            {
                entity.HasKey(e => e.IdStatusOrcamento);

                entity.ToTable("status_orcamento", "vendr");

                entity.Property(e => e.IdStatusOrcamento).HasColumnName("id_status_orcamento");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.DataRegistro)
                    .HasColumnName("data_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");
            });

            modelBuilder.Entity<StatusPedido>(entity =>
            {
                entity.HasKey(e => e.IdStatusPedido);

                entity.ToTable("status_pedido", "vendr");

                entity.Property(e => e.IdStatusPedido).HasColumnName("id_status_pedido");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.DataRegistro)
                    .HasColumnName("data_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");
            });

            modelBuilder.Entity<TipoDespesa>(entity =>
            {
                entity.HasKey(e => e.IdTipoDespesa);

                entity.ToTable("tipo_despesa", "vendr");

                entity.Property(e => e.IdTipoDespesa).HasColumnName("id_tipo_despesa");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.DataRegistro)
                    .HasColumnName("data_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__4E3E04ADCBE2932C");

                entity.ToTable("usuario", "vendr");

                entity.HasIndex(e => e.AssinaturaId);

                entity.HasIndex(e => e.Senha);

                entity.HasIndex(e => new { e.Email, e.Ativo });

                entity.HasIndex(e => new { e.Email, e.Senha, e.Ativo });

                entity.HasIndex(e => new { e.IdUsuario, e.Assinante, e.Email })
                    .HasName("IX_usuario_assinante_email");

                entity.HasIndex(e => new { e.IdUsuario, e.AssinaturaId, e.Assinante })
                    .HasName("IX_usuario_assinante");

                entity.HasIndex(e => new { e.IdUsuario, e.Email, e.Ativo })
                    .HasName("IX_usuario_ativo");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Assinante).HasColumnName("assinante");

                entity.Property(e => e.AssinaturaClienteId)
                    .HasColumnName("assinatura_cliente_id")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AssinaturaData)
                    .HasColumnName("assinatura_data")
                    .HasColumnType("datetime");

                entity.Property(e => e.AssinaturaId)
                    .HasColumnName("assinatura_id")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AssinaturaPlano).HasColumnName("assinatura_plano");

                entity.Property(e => e.AssinaturaTipo).HasColumnName("assinatura_tipo");

                entity.Property(e => e.AssinaturaTipoDescricao)
                    .HasColumnName("assinatura_tipo_descricao")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AssinaturaTipoPagamento).HasColumnName("assinatura_tipo_pagamento");

                entity.Property(e => e.AssinaturaTipoQtdeVendedor).HasColumnName("assinatura_tipo_qtde_vendedor");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasColumnName("ativo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hash)
                    .HasColumnName("hash")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasColumnName("tipo_usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuarioBanco>(entity =>
            {
                entity.HasKey(e => e.IdBancoUsuario)
                    .HasName("PK__usuario___2387F28C00179DF6");

                entity.ToTable("usuario_banco", "vendr");

                entity.Property(e => e.IdBancoUsuario).HasColumnName("id_banco_usuario");

                entity.Property(e => e.Agencia)
                    .IsRequired()
                    .HasColumnName("agencia")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Conta)
                    .IsRequired()
                    .HasColumnName("conta")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IdBanco).HasColumnName("id_banco");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.TipoConta)
                    .IsRequired()
                    .HasColumnName("tipo_conta")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBancoNavigation)
                    .WithMany(p => p.UsuarioBanco)
                    .HasForeignKey(d => d.IdBanco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario_b__id_ba__2A164134");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioBanco)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario_b__id_us__7D439ABD");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.IdVendedor)
                    .HasName("PK__vendedor__00930308F41E1435");

                entity.ToTable("vendedor", "vendr");

                entity.HasIndex(e => e.IdPerfil)
                    .HasName("ix_md_vendedor_id_perfil");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("ix_dm_vendr_vendedor_id_usuario");

                entity.HasIndex(e => e.IdVendedorPai);

                entity.HasIndex(e => new { e.IdVendedor, e.IdUsuario, e.IdPerfil, e.Ativo, e.IdVendedorPai })
                    .HasName("ix_md_vendedor_ativo_id_vendedor_pai");

                entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasColumnName("ativo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Frase)
                    .HasColumnName("frase")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IdVendedorPai).HasColumnName("id_vendedor_pai");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.LocalLastUpdate).HasColumnName("local_last_update");

                entity.Property(e => e.PorOndeConheceu)
                    .HasColumnName("por_onde_conheceu")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Vendedor)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__vendedor__id_per__51300E55");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Vendedor)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__vendedor__id_usu__02084FDA");
            });
        }
    }
}
