using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Cursos
{
	public class Editar
	{
		public class Ejecutar : IRequest
		{
			public int CursoId { get; set; }
			public string Titulo { get; set; }
			public string Descripcion { get; set; }
			public DateTime? FechaPublicacion { get; set; }
		}

		public class EjecutaValidaciones : AbstractValidator<Ejecutar>
		{
			public EjecutaValidaciones()
			{
				RuleFor(x => x.CursoId).NotEmpty();
				RuleFor(x => x.Titulo).NotEmpty();
				RuleFor(x => x.Descripcion).NotEmpty();
				RuleFor(x => x.FechaPublicacion).NotEmpty();
			}
		}

		public class Manejador : IRequestHandler<Ejecutar>
		{
			private readonly CursosOnlineContext _cursosOnlineContext;

			public Manejador(CursosOnlineContext cursosOnlineContext)
			{
				_cursosOnlineContext = cursosOnlineContext;
			}

			public async Task<Unit> Handle(Ejecutar request, CancellationToken cancellationToken)
			{
				var curso = await _cursosOnlineContext.Curso.FindAsync(request.CursoId);

				if (curso == null)
				{
					throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
				}

				curso.Titulo = request.Titulo ?? curso.Titulo;
				curso.Descripcion = request.Descripcion ?? curso.Descripcion;
				curso.FechaPublicacion = request.FechaPublicacion ?? curso.FechaPublicacion;


				var resultado = await _cursosOnlineContext.SaveChangesAsync();
				if (resultado > 0)
				{
					return Unit.Value;
				}

				throw new Exception("no se logro actualizar el curso");
			}
		}

	}
}