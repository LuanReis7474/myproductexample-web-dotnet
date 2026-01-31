using Microsoft.EntityFrameworkCore;
using myproductexameple_web_dotnet_domain;

namespace myproductexameple_web_dotnet_infra
{
    public class MyProductExampleDbContext : DbContext
    {
        
        public MyProductExampleDbContext(DbContextOptions<MyProductExampleDbContext> options)
            : base(options)
        {
        }

        public DbSet<PlanoConta> PlanoContas { get; set; } = null!;
        public DbSet<Transacao> Transacoes { get; set; } = null!;

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeamento para a tabela planoconta
            modelBuilder.Entity<PlanoConta>(entity =>
            {
                entity.ToTable("planoconta");
                entity.HasKey(e => e.Id).HasName("planoconta_pkey");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("character(1)")
                    .IsRequired();
            });

            // Mapeamento para a tabela transacao
            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.ToTable("transacao");
                entity.HasKey(e => e.Id).HasName("transacao_pkey");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Historico)
                    .HasColumnName("historico")
                    .HasColumnType("text")
                    .IsRequired(false); // permite null conforme seu DDL

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("numeric(9,2)");
                    //.IsRequired(false); // ajuste se quiser not null

                entity.Property(e => e.PlanoContaId)
                    .HasColumnName("planocontaid")
                    .IsRequired(false); // coluna nullable no DB

                entity.HasOne(e => e.PlanoConta)
                    .WithMany() // se tiver ICollection<Transacao> em PlanoConta, troque para p => p.Transacoes
                    .HasForeignKey(e => e.PlanoContaId)
                    .HasConstraintName("fk_planoconta")
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }


    }
}
