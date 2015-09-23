using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Estacionamento.Models.Mapping
{
    public class ModelosCarroMap : EntityTypeConfiguration<ModelosCarro>
    {
        public ModelosCarroMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ModelosCarro");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
