using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.Cursos
{
    public class ConsultaId
    {
        public class CursoUnico : IRequest<Curso> {
            public int Id {get;set;}
        }

		public class Manejador : IRequestHandler<CursoUnico, Curso>
		{
			private readonly CursosOnlineContext _cursosOnlineContext;

			public Manejador(CursosOnlineContext cursosOnlineContext)
			{
				_cursosOnlineContext = cursosOnlineContext;
			}

			public async Task<Curso> Handle(CursoUnico request, CancellationToken cancellationToken)
			{
				
                var curso = await _cursosOnlineContext.Curso.FindAsync(request.Id);

                return curso;

			}
		}

    }
}