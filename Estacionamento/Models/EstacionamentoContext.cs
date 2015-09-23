using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Estacionamento.Models.Mapping;

namespace Estacionamento.Models
{
    public partial class EstacionamentoContext : DbContext
    {
        static EstacionamentoContext()
        {
            Database.SetInitializer<EstacionamentoContext>(null);
        }

        public EstacionamentoContext()
            : base("Name=EstacionamentoContext")
        {
        }

        public DbSet<Fluxo> Fluxoes { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<ModelosCarro> ModelosCarroes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FluxoMap());
            modelBuilder.Configurations.Add(new HorarioMap());
            modelBuilder.Configurations.Add(new ModelosCarroMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }
    }
}
