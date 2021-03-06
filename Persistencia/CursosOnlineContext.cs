using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Persistencia
{
    public class CursosOnlineContext : DbContext
    {
        public CursosOnlineContext(DbContextOptions options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<CursoInstructor>().HasKey(ci=> new {ci.InstructorId , ci.CursoId});
        }

        public DbSet<Curso> Curso { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<CursoInstructor> CursoInstructor { get; set; }
        public DbSet<Precio> Precio { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
    }
}