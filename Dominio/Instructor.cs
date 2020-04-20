using System.Collections.Generic;
namespace Dominio
{
	public class Instructor
	{
		//campos tabla -->
		public int InstructorId { get; set; }
		public string Nombre { get; set; }
		public string Apellidos { get; set; }
		public string Grado { get; set; }
		public byte[] FotoPerfil { get; set; }

		//referencia a nivel de objetos -->
		public ICollection<CursoInstructor> CursoLink { get; set; }
	}
}