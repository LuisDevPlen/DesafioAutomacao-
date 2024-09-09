using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAecTeste.Models;

namespace apiTestes.Data.Map
{
    public class CursoItemMap : IEntityTypeConfiguration<CursoModel>
    {


        public void Configure(EntityTypeBuilder<CursoModel> builder)
        {

            //builder.ToTable("Cursos");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd(); // Garantir que o ID é gerado automaticamente

            builder.Property(c => c.Titulo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Professor)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.CargaHoraria)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Descricao)
                .IsRequired();
        }
    }
    }

