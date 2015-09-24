using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Estacionamento.Models.Mapping
{
    public class FluxoMap : EntityTypeConfiguration<Fluxo>
    {
        public FluxoMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Placa)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Modelo)
                .HasMaxLength(50);

            this.Property(t => t.Nome)
                .HasMaxLength(50);

            this.Property(t => t.Type)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Fluxo");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.Placa).HasColumnName("Placa");
            this.Property(t => t.Modelo).HasColumnName("Modelo");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.DataEntrada).HasColumnName("DataEntrada");
            this.Property(t => t.DataSaida).HasColumnName("DataSaida");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Valor).HasColumnName("Valor");
        }
    }
}
