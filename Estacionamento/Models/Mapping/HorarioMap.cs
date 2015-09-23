using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Estacionamento.Models.Mapping
{
    public class HorarioMap : EntityTypeConfiguration<Horario>
    {
        public HorarioMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Dia)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Horarios");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Dia).HasColumnName("Dia");
            this.Property(t => t.DataInicio).HasColumnName("DataInicio");
            this.Property(t => t.DataFim).HasColumnName("DataFim");
            this.Property(t => t.Valor).HasColumnName("Valor");
            this.Property(t => t.Type).HasColumnName("Type");
        }
    }
}
