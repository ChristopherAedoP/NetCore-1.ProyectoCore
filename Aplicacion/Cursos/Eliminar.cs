using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;

namespace Aplicacion.Cursos
{
	public class Eliminar
	{
		public class Ejecuta : IRequest
		{
			public int Id { get; set; }
		}

		public class Manejador : IRequestHandler<Ejecuta>
		{
			private readonly CursosOnlineContext _cursosOnlineContext;

			public Manejador(CursosOnlineContext cursosOnlineContext)
			{
				_cursosOnlineContext = cursosOnlineContext;
			}

			public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
			{
				var curso = await _cursosOnlineContext.Curso.FindAsync(request.Id);

				if (curso == null)
				{
					throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
				}

				_cursosOnlineContext.Remove(curso);

				var resultado = await _cursosOnlineContext.SaveChangesAsync();
				if (resultado > 0)
				{
					return Unit.Value;
				}

				throw new Exception("no se logro eliminar el curso");

			}
		}
	}
}