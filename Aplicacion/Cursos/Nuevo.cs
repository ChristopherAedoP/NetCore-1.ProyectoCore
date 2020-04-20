using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Cursos
{
	public class Nuevo
	{
		public class Ejecutar : IRequest
		{
			public string Titulo { get; set; }
			public string Descripcion { get; set; }
			public DateTime? FechaPublicacion { get; set; }
		}

		public class EjecutaValidaciones : AbstractValidator<Ejecutar> {
			public EjecutaValidaciones(){
				RuleFor(x=> x.Titulo).NotEmpty();
				RuleFor(x=> x.Descripcion).NotEmpty();
				RuleFor(x=> x.FechaPublicacion).NotEmpty();
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
				
                var curso = new Curso {
                    Titulo = request.Titulo,
                    Descripcion = request.Descripcion,
                    FechaPublicacion = request.FechaPublicacion
                };

                _cursosOnlineContext.Curso.Add(curso);
                var valor = await _cursosOnlineContext.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("no se logro guardar el curso");

			}
		}
	}
}