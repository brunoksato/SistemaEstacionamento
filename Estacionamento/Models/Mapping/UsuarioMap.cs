using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Estacionamento.Models.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Login)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Senha)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Usuario");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Login).HasColumnName("Login");
            this.Property(t => t.Senha).HasColumnName("Senha");
            this.Property(t => t.Admin).HasColumnName("Admin");
        }
    }
}
